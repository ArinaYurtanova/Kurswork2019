using EyeClinic.Model;
using EyeClinic.Service.Interface;
using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Implementation
{
    public class TherapyService: ITherapy
    {
        private EyeClinicDBContext context;

        public TherapyService(EyeClinicDBContext context)
        {
            this.context = context;
        }

        public List<TherapyView> GetList()
        {
            List<TherapyView> result = context.Therapys
                .Select(rec => new TherapyView
                {
                    Id = rec.Id,
                    TherapyName = rec.TherapyName,
                    Price = rec.Price,
                    TherapySchemes = context.TherapySchemes
                            .Where(recPC => recPC.TherapyId == rec.Id)
                            .Select(recPC => new TherapySchemesView
                            {
                                Id = recPC.Id,
                                TherapyId = recPC.TherapyId,
                                SchemeId = recPC.SchemeId,
                                SchemeName = recPC.Scheme.SchemeName,
                                SchemePrice = recPC.SchemePrice
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public TherapyView GetElement(int id)
        {
            Therapy element = context.Therapys.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new TherapyView
                {
                    Id = element.Id,
                    TherapyName = element.TherapyName,
                    Price = element.Price,
                    TherapySchemes = context.TherapySchemes
                            .Where(recPC => recPC.TherapyId == element.Id)
                            .Select(recPC => new TherapySchemesView
                            {
                                Id = recPC.Id,
                                TherapyId = recPC.TherapyId,
                                SchemeId = recPC.SchemeId,
                                SchemeName = recPC.Scheme.SchemeName,
                                SchemePrice = recPC.SchemePrice
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(TherapyView model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Therapy element = context.Therapys.FirstOrDefault(rec => rec.TherapyName == model.TherapyName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть лечение с таким названием");
                    }
                    element = new Therapy
                    {
                        TherapyName = model.TherapyName,
                        Price = model.Price
                    };
                    context.Therapys.Add(element);
                    context.SaveChanges();
                    var groupComponents = model.TherapySchemes
                                                .GroupBy(rec => rec.SchemeId)
                                                .Select(rec => new
                                                {
                                                    SchemeId = rec.Key,
                                                    Summa = rec.Sum(r => r.SchemePrice)
                                                });
                    foreach (var groupComponent in groupComponents)
                    {
                        context.TherapySchemes.Add(new TherapyScheme
                        {
                            TherapyId = element.Id,
                            SchemeId = groupComponent.SchemeId,
                            SchemePrice = groupComponent.Summa
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(TherapyView model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Therapy element = context.Therapys.FirstOrDefault(rec =>
                                        rec.TherapyName == model.TherapyName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Therapys.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.TherapyName = model.TherapyName;
                    element.Price = model.Price;
                    context.SaveChanges();

                    var compIds = model.TherapySchemes.Select(rec => rec.SchemeId).Distinct();
                    var updateComponents = context.TherapySchemes
                                                    .Where(rec => rec.TherapyId == model.Id &&
                                                        compIds.Contains(rec.SchemeId));
                    foreach (var updateComponent in updateComponents)
                    {
                        updateComponent.SchemePrice = model.TherapySchemes
                                                        .FirstOrDefault(rec => rec.Id == updateComponent.Id).SchemePrice;
                    }
                    context.SaveChanges();
                    context.TherapySchemes.RemoveRange(
                                        context.TherapySchemes.Where(rec => rec.TherapyId == model.Id &&
                                                                            !compIds.Contains(rec.SchemeId)));
                    context.SaveChanges();
                    var groupComponents = model.TherapySchemes
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.SchemeId)
                                                .Select(rec => new
                                                {
                                                    ComponentId = rec.Key,
                                                    Count = rec.Sum(r => r.SchemePrice)
                                                });
                    foreach (var groupComponent in groupComponents)
                    {
                        TherapyScheme elementPC = context.TherapySchemes
                                                .FirstOrDefault(rec => rec.TherapyId == model.Id &&
                                                                rec.SchemeId == groupComponent.ComponentId);
                        if (elementPC != null)
                        {
                            elementPC.SchemePrice += groupComponent.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.TherapySchemes.Add(new TherapyScheme
                            {
                                TherapyId = model.Id,
                                SchemeId = groupComponent.ComponentId,
                                SchemePrice = groupComponent.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Therapy element = context.Therapys.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.TherapySchemes.RemoveRange(
                                            context.TherapySchemes.Where(rec => rec.TherapyId == id));
                        context.Therapys.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}

