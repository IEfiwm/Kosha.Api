
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
namespace ZarkiaIntegratedSystem_Tax
{
    public class clsJobInsourence
    {
        public int Index { get; set; }
        public string Name { get; set; }
        [Key]
        public string Code { get; set; }

        
        //public static clsJobInsourence GetJobInsurenceInfo(int index, string NC)
        //{
        //   //ZarkiaEntities dB = new ZarkiaEntities(clsConnctionString.DMConnectionString);
        //    return (from j in clsSalVariable.joblist
        //            where j.Index == index || j.Name == NC || j.Code == NC
        //            select j).FirstOrDefault();
        //}

        //public static List<clsJobInsourence> SelectAll()
        //{
        //    //ZarkiaEntities dB = new ZarkiaEntities(clsConnctionString.DMConnectionString);
        //    return (from j in clsSalVariable.joblist select j).ToList();
        //}
    }
}
