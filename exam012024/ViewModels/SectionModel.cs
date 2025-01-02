using exam012024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace exam012024.ViewModels
{
    public class SectionModel
    {

        private readonly Section _monSection;
        private decimal total = 0;

        public SectionModel(Section current)
        {
            this._monSection = current;
        }

        public Section MonSection
        {
            get { return _monSection; }
        }

        public String Name
        {
            get
            {
                return _monSection.Name;

            }
        }

        public int SectionId
        {
            get
            {
                return _monSection.SectionId;
            }
        }
    }
}
