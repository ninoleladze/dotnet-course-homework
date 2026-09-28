using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingcart
{
    internal class Product
    { 
        private static int _counter=1;



        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string category { get; set; }
        public double Price { get; set; }


        public Product( )
        {
           Id = _counter++; 
        }

        public override string ToString()
        {
            return $"{Id}. {Name} - {Description} - {category} - ${Price}";
        }



    }
}
