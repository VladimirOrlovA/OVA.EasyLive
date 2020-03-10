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
        public int userId { get; set; }
        public int Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Length { get; set; }
    }
}