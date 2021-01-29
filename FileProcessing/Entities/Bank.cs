using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessing.Entities
{
    public class Bank
    {
        public string Name { get; set; }
        public List<Transfer> Transfers { get; set; }
    }
}
