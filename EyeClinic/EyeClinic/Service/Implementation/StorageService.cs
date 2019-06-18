using EyeClinic.Model;
using EyeClinic.Service.Interface;
using EyeClinic.Service.ViewModel;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Implementation
{
    public class StorageService: IStorage
    {
        private EyeClinicDBContext context;

        public StorageService(EyeClinicDBContext context)
        {
            this.context = context;
        }

        public List<StorageView> GetList()
        {
            List<StorageView> result = context.Storages
                .Select(rec => new StorageView
                {
                    Id = rec.Id,
                    StorageName = rec.StorageName,
                    StorageMedications = context.StorageMedications
                            .Where(recPC => recPC.StorageId == rec.Id)
                            .Select(recPC => new StorageMedicationView
                            {
                                Id = recPC.Id,
                                StorageId = recPC.StorageId,
                                MedicationId = recPC.MedicationId,
                                MedicationName = recPC.Medication.MedicationName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public StorageView GetElement(int id)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StorageView
                {
                    Id = element.Id,
                    StorageName = element.StorageName,
                    StorageMedications = context.StorageMedications
                            .Where(recPC => recPC.StorageId == element.Id)
                            .Select(recPC => new StorageMedicationView
                            {
                                Id = recPC.Id,
                                StorageId = recPC.StorageId,
                                MedicationId = recPC.MedicationId,
                                MedicationName = recPC.Medication.MedicationName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(StorageView model)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            context.Storages.Add(new Storage
            {
                StorageName = model.StorageName
            });
            context.SaveChanges();
        }

        public void UpdElement(StorageView model)
        {
            Storage element = context.Storages.FirstOrDefault(rec =>
                                        rec.StorageName == model.StorageName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StorageName = model.StorageName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Storage element = context.Storages.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // при удалении удаляем все записи о компонентах на удаляемом складе
                        context.StorageMedications.RemoveRange(
                                            context.StorageMedications.Where(rec => rec.StorageId == id));
                        context.Storages.Remove(element);
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

        public List<StoragesLoadView> GetStoragesLoad()
        {
            return context.Storages
                            .ToList()
                            .GroupJoin(
                                    context.StorageMedications
                                                .Include(r => r.Medication)
                                                .ToList(),
                                    storage => storage,
                                    storageMedication => storageMedication.Storage,
                                    (storage, storageCompList) =>
            new StoragesLoadView
            {
                StorageName = storage.StorageName,
                TotalCount = storageCompList.Sum(r => r.Count),
                Medications = storageCompList.Select(r => new Tuple<string, int>(r.Medication.MedicationName, r.Count))
            })
                            .ToList();
        }

        public void SaveStoragesLoad(StorageView model)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                //или создаем excel-файл, или открываем существующий
                if (File.Exists(model.FileName))
                {
                    excel.Workbooks.Open(model.FileName, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(model.FileName, XlFileFormat.xlExcel8, Type.Missing,
                        Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                Sheets excelsheets = excel.Workbooks[1].Worksheets;
                //Получаем ссылку на лист
                var excelworksheet = (Worksheet)excelsheets.get_Item(1);
                //очищаем ячейки
                excelworksheet.Cells.Clear();
                //настройки страницы
                excelworksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                excelworksheet.PageSetup.CenterHorizontally = true;
                excelworksheet.PageSetup.CenterVertically = true;
                //получаем ссылку на первые 3 ячейки
                Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.get_Range("A1", "C1");
                //объединяем их
                excelcells.Merge(Type.Missing);
                //задаем текст, настройки шрифта и ячейки
                excelcells.Font.Bold = true;
                excelcells.Value2 = "Загруженность складов";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                excelcells = excelworksheet.get_Range("A2", "C2");
                excelcells.Merge(Type.Missing);
                excelcells.Value2 = "на" + DateTime.Now.ToShortDateString();
                excelcells.RowHeight = 20;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;

                var dict = GetStoragesLoad();
                if (dict != null)
                {
                    excelcells = excelworksheet.get_Range("C1", "C1");
                    foreach (var elem in dict)
                    {
                        //спускаемся на 2 ячейку вниз и 2 ячейкт влево
                        excelcells = excelcells.get_Offset(2, -2);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = elem.StorageName;
                        excelcells = excelcells.get_Offset(1, 1);
                        //обводим границы
                        if (elem.Medications.Count() > 0)
                        {
                            //получаем ячейкт для выбеления рамки под таблицу
                            var excelBorder =
                                excelworksheet.get_Range(excelcells,
                                            excelcells.get_Offset(elem.Medications.Count() - 1, 1));
                            excelBorder.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelBorder.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                            excelBorder.HorizontalAlignment = Constants.xlCenter;
                            excelBorder.VerticalAlignment = Constants.xlCenter;
                            excelBorder.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
                                                    Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium,
                                                    Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
                                                    1);

                            foreach (var listElem in elem.Medications)
                            {
                                excelcells.Value2 = listElem.Item1;
                                excelcells.ColumnWidth = 10;
                                excelcells.get_Offset(0, 1).Value2 = listElem.Item2;
                                excelcells = excelcells.get_Offset(1, 0);
                            }
                        }
                        excelcells = excelcells.get_Offset(0, -1);
                        excelcells.Value2 = "Итого";
                        excelcells.Font.Bold = true;
                        excelcells = excelcells.get_Offset(0, 2);
                        excelcells.Value2 = elem.TotalCount;
                        excelcells.Font.Bold = true;
                    }
                }
                //сохраняем
                excel.Workbooks[1].Save();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //закрываем
                excel.Quit();
            }
        }
        public void PutComponentOnStock(StorageMedicationView model)
        {
            StorageMedication element = context.StorageMedications
                                                .FirstOrDefault(rec => rec.StorageId == model.StorageId &&
                                                                    rec.MedicationId == model.MedicationId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StorageMedications.Add(new StorageMedication
                {
                    StorageId = model.StorageId,
                    MedicationId = model.MedicationId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}

