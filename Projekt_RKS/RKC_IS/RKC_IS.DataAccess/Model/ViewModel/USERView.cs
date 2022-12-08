using RKC_IS.DataAccess.Model.AutoMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKC_IS.DataAccess.Model.ViewModel
{
   public class USERView
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();
        public IEnumerable<USER> userS { get; set; }
        public int UserPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(userS.Count() / (double)UserPerPage));
        }
        public IEnumerable<USER> PaginatedUser()
        {
            int start = (CurrentPage - 1) * UserPerPage;
            return userS.OrderBy(b => b.ID).Skip(start).Take(UserPerPage);
        }

        //public IEnumerable<USER> GetMyUserPaged(int count, int page, out int totalMyUser)
        //{
        //    //USER localUser = new USER();
        //    totalMyUser = userS.Count();
        //    int start = (page - 1) * count;
        //    return userS.OrderBy(b => b.ID).Skip(start).Take(count);


        //    //return db.USER.ToList();

        //    //(page - 1) * count
        //}
    }
}
