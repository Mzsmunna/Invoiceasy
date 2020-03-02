using Invoiceasy.Entity;
using Invoiceasy.Manager;
using Invoiceasy.MongoRepository.Core;
using Invoiceasy.MongoRepository.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Helper
{
    public class Experiment
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ExecuteMongoDBOperations()
        {
            try
            {               
                if (CheckForInternetConnection())
                {
                    //var dealerRepo = new DealerRepository(new MongoDbContext());
                    var dealerRepo = new DynamicRepository<DealerEntity>(new MongoDbContext());

                    var results = dealerRepo.GetAllData().Result;

                    //dealerRepo.DropDealer();

                    var dealers = DealerManager.GetAllDealers();

                    var dealerList = JsonConvert.DeserializeObject<List<DealerEntity>>(JsonConvert.SerializeObject(dealers));

                    foreach (var dealer in dealerList)
                    {
                        dealer.Created_On = DateTime.Now;
                        dealer.Modified_On = DateTime.Now;
                        dealerRepo.Save(dealer);
                    }

                    //var results = dealerRepo.GetAllDealers().Result;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }         
        }
    }
}
