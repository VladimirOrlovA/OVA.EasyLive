using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVA.EasyLive.DAL
{
    public class Vacation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Length { get; set; }
    }
}