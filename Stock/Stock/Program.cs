using System;
using System.Collections.Generic;

namespace Stock
{
  class Program
  {
    private const string CONNECTION_STRING = "Server=A-305-07;Database=Stock;Trusted_Connection=True;";
    static void Main(string[] args)
    {
      WaybillRepository waybillRepository = new WaybillRepository(CONNECTION_STRING);
      StockerRepository stockerRepository = new StockerRepository(CONNECTION_STRING);
      // Add

      while (true)
      {
        Console.WriteLine("1.Принять товар      \n" +
                          "2.Отправить товар    \n" +
                          "3.Изменить товар     \n" +
                          "4.Список товаров     \n" +
                          "5.Список кладовщиков \n" +
                          "6.Добавить товара    \n" +
                          "0.Выход              \n");

        int chooiseMainMenu;
        if (int.TryParse(Console.ReadLine(), out chooiseMainMenu))
        {
          switch (chooiseMainMenu)
          {
            case 1:
              {
                InsertWaybill(stockerRepository);
                break;
              } // case 1 switch(а) - контролер меню
            case 2:
              {
                DepartureWaybill(stockerRepository);
                break;
              } // case 2 switch(а) - контролер меню
            case 3:
              {
                UpdateWaybill(stockerRepository);
                break;
              } // case 3 switch(а) - контролер меню
            case 4:
              {
                ProductRepository productRepository = new ProductRepository(CONNECTION_STRING);
                var products = productRepository.GetProducts() as List<Product>;
                PrintProducts(products);
                break;
              } // case 4 switch(а) - контролер меню
            case 5:
              {
                var stockers = stockerRepository.GetStockers() as List<Stocker>;
                PrintStockers(stockers);
                break;
              } // case 5 switch(а) - контролер меню
            case 0:
              {
                return;
              } // case 0 switch(а) - контролер меню
          } // switch - контролер меню
        } // if из выбора основного меню
        else
        {
          Console.Clear();
          Console.WriteLine("Не корректный ввод!\n" +
                            "Нажмите Enter ...");
          Console.ReadLine();
        } // else из выбора основного меню
        Console.Clear();
      }
    }

    private static void UpdateWaybill(StockerRepository stockerRepository)
    {
      WaybillRepository waybillRepository = new WaybillRepository(CONNECTION_STRING);
      var waybills = waybillRepository.GetAll()as List<Waybill>;
      int i = 0;
      Console.WriteLine(" № | Id накладного | Принять/Отправить | Получатель/Поставщик | Id кладовщика | Дата отправки/Дата получения |");
      foreach (var waybill in waybills)
      {
        if (waybill.IsExport == true) {
          Console.WriteLine($"{++i} | {waybill.Id} | {waybill.IsExport} | {waybill.Receiver} | {waybill.StockerId} | {waybill.DeliveryDate} |");
        } else
        {
          Console.WriteLine($"{++i} | {waybill.Id} | {waybill.IsExport} | {waybill.Provider} | {waybill.StockerId} | {waybill.DepartureDate} |");
        }
      }
      while (true)
      {
        int chooise = 0;
        if(int.TryParse(Console.ReadLine(), out chooise))
        {
          chooise--;
          if(chooise >= 0 && chooise < waybills.Count)
          {
            if(waybills[chooise].IsExport == true)
            {
              Console.WriteLine("Измените получателя:");
              waybills[chooise].Receiver = Console.ReadLine();
            } else
            {
              Console.WriteLine("Измените поставщика:");
              waybills[chooise].Receiver = Console.ReadLine();
            }
          }
        }
      }
    }

    private static void DepartureWaybill(StockerRepository stockerRepository)
    {
      Waybill waybillDeparture = new Waybill();
      while (true)
      {
        Console.WriteLine("Выберите кладовщика: ");
        var IdStockers = stockerRepository.GetStockers() as List<Stocker>;
        PrintStockers(IdStockers);
        int chooiseStocker = 0;
        if (int.TryParse(Console.ReadLine(), out chooiseStocker))
        {
          --chooiseStocker;
          if (chooiseStocker >= 0 && chooiseStocker < IdStockers.Count)
          {
            waybillDeparture.StockerId = IdStockers[chooiseStocker].Id;
            break;
          }
          else
          {
            Console.WriteLine("Ваш выбор не корректен!");
          }
        }
        else
        {
          Console.WriteLine("Не корретно!");
        }
      }
      waybillDeparture.IsExport = true;
      Console.WriteLine("Имя получатель: ");
      waybillDeparture.Provider = Console.ReadLine();
      waybillDeparture.DeliveryDate = DateTime.Now;
    }

    private static void InsertWaybill(StockerRepository stockerRepository)
    {
      Waybill waybillAdd = new Waybill();
      while (true)
      {
        Console.WriteLine("Выберите кладовщика: ");
        var IdStockers = stockerRepository.GetStockers() as List<Stocker>;
        PrintStockers(IdStockers);
        int chooiseStocker = 0;
        if (int.TryParse(Console.ReadLine(), out chooiseStocker))
        {
          --chooiseStocker;
          if (chooiseStocker >= 0 && chooiseStocker < IdStockers.Count)
          {
            waybillAdd.StockerId = IdStockers[chooiseStocker].Id;
            break;
          }
          else
          {
            Console.WriteLine("Ваш выбор не корректен!");
          }
        }
        else
        {
          Console.WriteLine("Не корретно!");
        }
      }
      waybillAdd.IsExport = false;
      Console.WriteLine("Имя поставщика: ");
      waybillAdd.Provider = Console.ReadLine();
      waybillAdd.DepartureDate = DateTime.Now;
    }

    private static void PrintProducts(List<Product> products)
    {
      Console.WriteLine(" Id товара | Имя товара | Кол-во товара | Id накладного |");
      foreach (var product in products)
      {
        Console.WriteLine($"{product.Id} | {product.Name} | {product.Count} | {product.Waybill} |");
      }
    }

    private static void PrintStockers(List<Stocker> stockers)
    {
      int i = 0;
      foreach (var stocker in stockers)
      {
        Console.WriteLine($"{++i} | {stocker.Id} | {stocker.Name}");
      }
    }
  }
}
