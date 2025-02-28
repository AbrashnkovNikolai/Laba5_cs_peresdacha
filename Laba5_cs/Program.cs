using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Aspose.Cells;


void Main()
{
    DataBase bd = new DataBase("LR5-var1.xls");

    //Console.Write(bd.ToString());
    while (true)
    {
       
        Console.WriteLine("Выберите опцию:");
        Console.WriteLine("1. Движение товаров");
        Console.WriteLine("2. Товары");
        Console.WriteLine("3. Магазины");
        Console.WriteLine("4. Категории");
        Console.WriteLine("5. удаление по id");
        Console.WriteLine("0. Выход");
        Console.Write("Введите номер опции: ");
        
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine(bd.wiewPM());
                //ManageProductMovements();
                break;

            case "2":
                Console.WriteLine(bd.wiewPRODS());
                //ManageProducts()
                break;

            case "3":
                Console.WriteLine(bd.wiewSTORES());
                Console.WriteLine("выручка магазина с id = P7 "+bd.GetTotalProfitInStores("Р7").ToString());
                break;

            case "4":
                Console.WriteLine(bd.wiewCATS());
                //ManageStores();
                break;

            case "0":
                Console.WriteLine("Выход из программы...");
                return;
            case "5":
                int input5 = UserInput.intInput(true,"введите номер таблицы ");
                int input55 = UserInput.intInput(true, "введите id что желаете удалить ");
                bd.DelElById(input5, input55);
                //ManageStores();
                break;
            default:
                Console.WriteLine("Некорректный ввод. Пожалуйста, попробуйте снова.");
                break;
        }
        bd.Save();

    }



            }


Main();




public class ProductMovement
{
    public int IdOperation;
    public DateOnly date;
    public string idStore;
    public int art;
    public string operationType;
    public int quantityPackages;
    public string hasCustomerCard;

    public ProductMovement(int IdOperation, DateOnly date, string idStore, int art, string operationType, int quantityPackages, string hasCustomerCard)
    {
        this.IdOperation = IdOperation;
        this.date = date;
        this.idStore = idStore;
        this.art = art;
        this.operationType = operationType;
        this.quantityPackages = quantityPackages;
        this.hasCustomerCard = hasCustomerCard;
    }

    public int GetIdOperation() => IdOperation;
    public void SetIdOperation(int IdOperation) => this.IdOperation = IdOperation;

    public DateOnly GetDate() => date;
    public void SetDate( DateOnly date) => this.date = date;

    public string GetIdStore() => idStore;
    public void SetIdStore(string idStore) => this.idStore = idStore;

    public int GetArt() => art;
    public void SetArt(int art) => this.art = art;

    public string GetOperationType() => operationType;
    public void SetOperationType(string operationType) => this.operationType = operationType;

    public int GetQuantityPackages() => quantityPackages;
    public void SetQuantityPackages(int quantityPackages) => this.quantityPackages = quantityPackages;

    public string GetHasCustomerCard() => hasCustomerCard;
    public void SetHasCustomerCard(string hasCustomerCard) => this.hasCustomerCard = hasCustomerCard;

    public override string ToString()
    {
        return $"ID операции: {IdOperation}, Дата: {date}, ID магазина: {idStore}, Артикул: {art}, Тип операции: {operationType}, Количество упаковок: {quantityPackages}, Наличие карты клиента: {hasCustomerCard}";
    }
}

public class Product
{
    public int art;
    public int idCategory;
    public string productName;
    public float purchasePrice;
    public float salePrice;
    public float customerCardDiscount;

    public Product(int art, int idCategory, string productName, float purchasePrice, float salePrice, float customerCardDiscount)
    {
        this.art = art;
        this.idCategory = idCategory;
        this.productName = productName;
        this.purchasePrice = purchasePrice;
        this.salePrice = salePrice;
        this.customerCardDiscount = customerCardDiscount;
    }

    public int GetArt() => art;
    public void SetArt(int art) => this.art = art;

    public int GetIdCategory() => idCategory;
    public void SetIdCategory(int idCategory) => this.idCategory = idCategory;

    public string GetProductName() => productName;
    public void SetProductName(string productName) => this.productName = productName;

    public float GetPurchasePrice() => purchasePrice;
    public void SetPurchasePrice(float purchasePrice) => this.purchasePrice = purchasePrice;

    public float GetSalePrice() => salePrice;
    public void SetSalePrice(float salePrice) => this.salePrice = salePrice;

    public float GetCustomerCardDiscount() => customerCardDiscount;
    public void SetCustomerCardDiscount(float customerCardDiscount) => this.customerCardDiscount = customerCardDiscount;

    public override string ToString()
    {
        return $"Артикул: {art}, ID категории: {idCategory}, Наименование товара: {productName}, Цена закупки: {purchasePrice}, Цена продажи: {salePrice}, Скидка по карте клиента: {customerCardDiscount}";
    }
}

public class Category
{
    public int id;
    public string name;
    public string ageRest;

    public Category(int id, string name, string ageRest)
    {
        this.id = id;
        this.name = name;
        this.ageRest = ageRest;
    }

    public int GetId() => id;
    public void SetId(int id) => this.id = id;

    public string GetName() => name;
    public void SetName(string name) => this.name = name;

    public string GetAgeRest() => ageRest;
    public void SetAgeRest(string ageRest) => this.ageRest = ageRest;

    public override string ToString()
    {
        return $"ID категории: {id}, Название категории: {name}, Возрастное ограничение: {ageRest}";
    }
}

public class Store
{
    public string id;
    public string district;
    public string address;

    public Store(string id, string district, string address)
    {
        this.id = id;
        this.district = district;
        this.address = address;
    }

    public string GetId() => id;
    public void SetId(string id) => this.id = id;

    public string GetDistrict() => district;
    public void SetDistrict(string district) => this.district = district;

    public string GetAddress() => address;
    public void SetAddress(string address) => this.address = address;

    public override string ToString()
    {
        return $"ID магазина: {id}, Район: {district}, Адрес: {address}";
    }
}

class DataBase
{
    private string file = "LR5-var1.xls";

    public List<ProductMovement> productMovements;
    public List<Product> products;
    public List<Category> categories;
    public List<Store> stores;

    public DataBase(string file= "LR5-var1.xls")
    {
        this.file = file;

        if (!File.Exists(file))
            throw new Exception("Файла с заданным путем не существует!");

        if (!file.EndsWith(".xls"))
            throw new Exception("Тип файла должен быть xls!");

        Workbook wb = new Workbook(file);

        productMovements = new List<ProductMovement>();
        products = new List<Product>();
        categories = new List<Category>();
        stores = new List<Store>();


        // Загрузка ProductMovement
        Worksheet ws = wb.Worksheets[0];
        
        for (int i = 1; i <= ws.Cells.MaxDataRow; i++)
        {
            Row row = ws.Cells.Rows[i];

            string dateString = row[1].StringValue;
            Console.WriteLine(dateString);

            // Разбиваем строку на компоненты
            dateString = dateString.Replace('.', '/');
            //string[] dateParts = dateString.Split('/');
            //Console.WriteLine(dateParts[0]);
            //Console.WriteLine(dateParts[1]);
            //Console.WriteLine(dateParts[2]);
            DateOnly DO = DateOnly.Parse(dateString);
            //if (dateParts.Length == 3 &&
            //    int.TryParse(dateParts[0], out int d) &&
            //    int.TryParse(dateParts[1], out int m) &&
            //    int.TryParse(dateParts[2], out int y))
            //{
            //    DateOnly dateOnlyVal =new (y, m,d);

            //    // Создаем DateOnly из DateTime
                
                productMovements.Add(new ProductMovement(
                row[0].IntValue,
                DO,
                row[2].StringValue,
                row[3].IntValue,
                row[4].StringValue,
                row[5].IntValue,
                row[6].StringValue));
                Style style = ws.Cells[i, 2].GetStyle(); //господи зачем я мучался с датой если ее можно было оставить стрингом
                style.Number = 14; 
                ws.Cells[i, 2].SetStyle(style);
            


        }

        // Загрузка Products
        ws = wb.Worksheets[1];
        for (int i = 1; i <= ws.Cells.MaxDataRow; i++)
        {
            Row row = ws.Cells.Rows[i];
            products.Add(new Product(
                row[0].IntValue,
                row[1].IntValue,
                row[2].StringValue,
                row[3].FloatValue,
                row[4].FloatValue,
                row[5].FloatValue
            ));
        }

        // Загрузка Categories
        ws = wb.Worksheets[2];
        for (int i = 1; i <= ws.Cells.MaxDataRow; i++)
        {
            Row row = ws.Cells.Rows[i];
            categories.Add(new Category(
                row[0].IntValue,
                row[1].StringValue,
                row[2].StringValue
            ));
        }

        // Загрузка Stores
        ws = wb.Worksheets[3];
        for (int i = 1; i <= ws.Cells.MaxDataRow; i++)
        {
            Row row = ws.Cells.Rows[i];
            stores.Add(new Store(
                row[0].StringValue,
                row[1].StringValue,
                row[2].StringValue
            ));
        }
    }


    public void AddProductMovement(DateOnly date, string idStore, int art, string operationType, int quantityPackages, string  hasCustomerCard)
    {
        //bool isYes = hasCustomerCard.Equals("Да")? true : false;
        int newId = productMovements.Count > 0 ? productMovements.Max(m => m.IdOperation) + 1 : 1;
        productMovements.Add(new ProductMovement(newId, date, idStore, art, operationType, quantityPackages, hasCustomerCard));
        this.Save();
    }

    public void AddProduct(int art, int idCategory, string productName, float purchasePrice, float salePrice, float customerCardDiscount)
    {
        products.Add(new Product(art, idCategory, productName, purchasePrice, salePrice, customerCardDiscount));
        this.Save();
    }

    public void AddCategory(int id, string name, string ageRest)
    {
        categories.Add(new Category(id, name, ageRest));
        this.Save();
    }

    public void AddStore(string id, string district, string address)
    {
        stores.Add(new Store(id, district, address));
        this.Save();
    }

    public void delPM(int id)
    {
        var movement = productMovements.FirstOrDefault(m => m.IdOperation == id);
        if (movement != null)
        {
            productMovements.Remove(movement);
            Console.WriteLine($"Движение товара с ID {id} удалено.");
        }
        else
        {
            Console.WriteLine($"Движение товара с ID {id} не найдено.");
        }
    }

    public void delPROD(int id)
    {
        var product = products.FirstOrDefault(p => p.art == id);
        if (product != null)
        {
            products.Remove(product);
            Console.WriteLine($"Товар с ID {id} удален.");
        }
        else
        {
            Console.WriteLine($"Товар с ID {id} не найден.");
        }
    }

    public void delCAT(int id)
    {
        var category = categories.FirstOrDefault(c => c.id == id);
        if (category != null)
        {
            categories.Remove(category);
            Console.WriteLine($"Категория с ID {id} удалена.");
        }
        else
        {
            Console.WriteLine($"Категория с ID {id} не найдена.");
        }
    }

    public void delSTORE(string id)
    {
        var store = stores.FirstOrDefault(s => s.id == id);
        if (store != null)
        {
            stores.Remove(store);
            Console.WriteLine($"Магазин с ID {id} удален.");
        }
        else
        {
            Console.WriteLine($"Магазин с ID {id} не найден.");
        }
    }
    public void AddelByID(int idTable, int id)
    {
        if (idTable < 0 || idTable > 4)
            throw new Exception($"таблицы с id '{idTable}' не существеут");

        switch (idTable - 1)
        {
            case 0:
                //this.AddProductMovement(id);
                break;
            case 1:
                this.delPROD(id);
                break;
            case 2:
                this.delCAT(id);
                break;
            case 3:
                this.delSTORE("Р" + id.ToString());
                break;
        }

        this.Save();
    }

    public void DelElById(int idTable, int id)
    {
        if (idTable < 0 || idTable > 4)
            throw new Exception($"таблицы с id '{idTable}' не существеут");

        switch (idTable-1)
        {
            case 0:
                this.delPM(id);
                break;
            case 1:
                this.delPROD(id);
                break;
            case 2:
                this.delSTORE("Р"+id.ToString());
                break;
                case 3:
                this.delCAT(id);
                break;
        }

        this.Save();
    }


    public void Save()
    {
        Workbook wb = new Workbook("LR5-var1.xls");

        // Сохранение ProductMovement
        Worksheet ws = wb.Worksheets[0];
        ws.Cells.DeleteRows(1, ws.Cells.Rows.Count - 1);
        foreach (ProductMovement pm in productMovements)
        {
            ws.Cells.InsertRow(ws.Cells.MaxDataRow + 1);
            ws.Cells.Rows[^1][0].PutValue(pm.IdOperation);
            ws.Cells.Rows[^1][1].PutValue(pm.date);
            ws.Cells.Rows[^1][2].PutValue(pm.idStore);
            ws.Cells.Rows[^1][3].PutValue(pm.art);
            ws.Cells.Rows[^1][4].PutValue(pm.operationType);
            ws.Cells.Rows[^1][5].PutValue(pm.quantityPackages);
            ws.Cells.Rows[^1][6].PutValue(pm.hasCustomerCard);
        }

        // Сохранение Products
        ws = wb.Worksheets[1];
        ws.Cells.DeleteRows(1, ws.Cells.Rows.Count - 1);
        foreach (Product p in products)
        {
            ws.Cells.InsertRow(ws.Cells.MaxDataRow + 1);
            ws.Cells.Rows[^1][0].PutValue((int)p.art);
            ws.Cells.Rows[^1][1].PutValue(p.idCategory);
            ws.Cells.Rows[^1][2].PutValue(p.productName);
            ws.Cells.Rows[^1][3].PutValue(p.purchasePrice);
            ws.Cells.Rows[^1][4].PutValue(p.salePrice);
            ws.Cells.Rows[^1][5].PutValue(p.customerCardDiscount);
        }

        // Сохранение Categories
        ws = wb.Worksheets[2];
        ws.Cells.DeleteRows(1, ws.Cells.Rows.Count - 1);
        foreach (Category c in categories)
        {
            ws.Cells.InsertRow(ws.Cells.MaxDataRow + 1);
            ws.Cells.Rows[^1][0].PutValue(c.id);
            ws.Cells.Rows[^1][1].PutValue(c.name);
            ws.Cells.Rows[^1][2].PutValue(c.ageRest);
        }

        // Сохранение Stores
        ws = wb.Worksheets[3];
        ws.Cells.DeleteRows(1, ws.Cells.Rows.Count - 1);
        foreach (Store s in stores)
        {
            ws.Cells.InsertRow(ws.Cells.MaxDataRow + 1);
            ws.Cells.Rows[^1][0].PutValue(s.id);
            ws.Cells.Rows[^1][1].PutValue(s.district);
            ws.Cells.Rows[^1][2].PutValue(s.address);
        }

        wb.Save(file);
    }

    public override string ToString()
    {
        return wiewALL();
    }
    public string wiewALL()
    {
        return wiewPM() + wiewPRODS() + wiewCATS() + wiewSTORES();
    }
    public string wiewPM()
    {
        string result = "Product Movements:\n";
        foreach (var pm in productMovements)
        {
            result += pm.ToString() + "\n";
        }
        result += "\n";
        return result;
    }
    public string wiewPRODS()
    {
        string result = "Products:\n";
        foreach (var p in products)
        {
            result += p.ToString() + "\n";
        }
        result += "\n";
        return result;
    }
    public string wiewCATS()
    {
        string result = "categories:\n";
        foreach (var p in categories)
        {
            result += p.ToString() + "\n";
        }
        result += "\n";
        return result;
    }
    public string wiewSTORES()
    {
        string result = "stores:\n";
        foreach (var p in stores)
        {
            result += p.ToString() + "\n";
        }
        result += "\n";
        return result;
    }

    public decimal GetTotalProfitInStores(string storeId)
    {
        return productMovements.Where(pm => pm.idStore == storeId && pm.hasCustomerCard == "Нет") 
            .Join<ProductMovement, Product, int, decimal>(
                products,
                pm => pm.art, 
                p => p.art,   
                (pm, p) => (decimal)p.purchasePrice * (decimal)pm.quantityPackages 
            )
            .Sum() +  

    productMovements.Where(pm => pm.idStore == storeId && pm.hasCustomerCard == "Да") 
    .Join<ProductMovement, Product, int, decimal>(
        products,
        pm => pm.art, 
        p => p.art,   
        (pm, p) => (decimal)p.salePrice * (decimal)pm.quantityPackages 
    )
    .Sum();
    
    }


}


