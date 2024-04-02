using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private DateTime _creationDate;

        public string code
        {
            get { return _code; }
            set
            {
                _code = value;
            }
        }
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        public int amount
        {
            get { return _amount; }
            set
            {
                if (value > 0)
                    _amount = value;
                else
                    _amount = 0;
            }
        }
        public float price
        {
            get { return _price; }
            set
            {
                if (value > 0)
                    _price = value;
                else
                    _price = 0;
            }
        }
        public DateTime CreationDate
        {
            get => _creationDate;
            set => _creationDate = value; 
        }
        public ENProduct()
        {
            code = null;
            name = null;
            amount = 0;
        }
        public ENProduct(string code, string name, int amount)
        {
            this.code = code;
            this.name = name;
            this.amount = amount;
        }
        public bool Create()
        {
            CADProduct cad = new CADProduct();
            if (cad.Read(this))
                return false;
            else
                return cad.Create(this);
        }
        public bool Read()
        {
            CADProduct cad = new CADProduct();
            return cad.Read(this);
        }
        public bool ReadFirst()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadFirst(this);
        }
        public bool ReadNext()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadNext(this);
        }
        public bool ReadPrev()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadPrev(this);
        }
        public bool Update()
        {
            CADProduct cad = new CADProduct();
            return cad.Update(this);
        }
        public bool Delete()
        {
            CADProduct cad = new CADProduct();
            return cad.Delete(this);
        }
    }
}