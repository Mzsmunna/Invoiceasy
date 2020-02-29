using Invoiceasy.Helper;
using Invoiceasy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Manager
{
    public static class DealerManager
    {
        private static List<DealerModel> DealerList { get; set; }
        private static readonly string dealerFilePath;

        static DealerManager()
        {
            dealerFilePath = @"\Libs\Files\CoreFiles\DataFiles\DelerList.txt";

            if (DealerList == null)
            {
                DealerList = new List<DealerModel>();
                LoadAllDealers();
            }
        }

        public static List<DealerModel> LoadAllDealers()
        {
            DealerList = CsvHelperUtility.ReadDataFromFile<DealerModel, DealerModelMap>(dealerFilePath);
            return DealerList;
        }

        public static List<DealerModel> GetAllDealers()
        {
            return DealerList;
        }

        public static int GetAllDealersCount()
        {
            return DealerList.Count;
        }

        public static DealerModel FindDealer(string dealerCode)
        {
            var findDealer = DealerList.Where(x => x.Code.ToLower().Equals(dealerCode.ToLower())).FirstOrDefault();
            return findDealer;
        }

        public static DealerModel SearchDealer(DealerModel dealer)
        {
            var findDealer = DealerList.Where(x => x.Code.ToLower().Equals(dealer.Code.ToLower())).FirstOrDefault();
            return findDealer;
        }

        public static List<DealerModel> SearchDealers(DealerModel dealer)
        {
            var findDealerList = DealerList.Where(x => x.Code.ToLower().Contains(dealer.Code.ToLower())).ToList();
            return findDealerList;
        }

        public static bool AddDealer(DealerModel dealer)
        {
            var dealerCodeExist = DealerList.Where(x => !(x.Sl.Equals(dealer.Sl)) && x.Code.ToLower().Equals(dealer.Code.ToLower())).FirstOrDefault();

            if (dealerCodeExist == null)
            {
                DealerList.Add(dealer);
                SaveChange();
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool AddManyDealers(List<DealerModel> dealers)
        {
            DealerList.AddRange(dealers);
            SaveChange();
            return true;
        }

        private static void SaveChange()
        {
            DealerList.RemoveAll(item => item == null);
            CsvHelperUtility.WriteDataToFile<DealerModel>(false, dealerFilePath, ",", DealerList);
            LoadAllDealers();
        }

        public static bool UpdateDealer(DealerModel dealer)
        {
            var findDealer = DealerList.Where(x => x.Sl.Equals(dealer.Sl)).FirstOrDefault();

            var dealerCodeExist = DealerList.Where(x => !(x.Sl.Equals(dealer.Sl)) && x.Code.ToLower().Equals(dealer.Code.ToLower())).FirstOrDefault();

            if (findDealer != null && dealerCodeExist == null)
            {
                findDealer = dealer;
                SaveChange();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateAllDealers(List<DealerModel> dealers)
        {
            DealerList = dealers;
            SaveChange();
            return true;
        }

        public static bool DeleteDealer(DealerModel dealer)
        {
            var findDealer = DealerList.Where(x => x.Code.ToLower().Equals(dealer.Code.ToLower()) || x.Sl.Equals(dealer.Sl)).FirstOrDefault();

            if (findDealer != null)
            {
                DealerList.Remove(findDealer);

                int sl = 1;

                foreach (var item in DealerList)
                {
                    item.Sl = sl.ToString();
                    sl++;
                }

                UpdateAllDealers(DealerList);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteManyDealers(List<DealerModel> dealers)
        {
            foreach (var dealer in dealers)
            {
                var findDealer = DealerList.Where(x => x.Code.Equals(dealer.Code)).FirstOrDefault();

                if (findDealer != null)
                {
                    DealerList.Remove(findDealer);
                }
            }

            SaveChange();
            return true;
        }
    }
}
