using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using exam012024.Models;

namespace exam012024.ViewModels
{
    public class StudentModel : INotifyPropertyChanged
    {
        private readonly Student _monStudent;

        public Student MonStudent
        {
            get { return _monStudent; }
        }

        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }



        public StudentModel(Student current)
        {
            this._monStudent = current;
        }

    
        public string FullName
        {
            get { return String.Format("{0} {1}", _monStudent.Firstname, _monStudent.Name).Trim(); }
          
        }


        public String StudentFirstname
        {
            get
            {
                return _monStudent.Firstname;
            }
            set
            {
                _monStudent.Firstname = value;
                OnPropertyChanged("FullName");
            }
        }

        public String StudentName
        {
            get
            {
                return _monStudent.Name;
            }
            set
            {
                _monStudent.Name = value;
                OnPropertyChanged("FullName");
            }
        }

        public Section Section
        {
            get
            {
                return _monStudent.Section ?? new Section();
            }
            set
            {
                if (_monStudent.Section != value)
                {
                    _monStudent.Section = value;
                    _monStudent.SectionId = value.SectionId; // Mettre à jour la clé étrangère
                    OnPropertyChanged(nameof(Section));
                    OnPropertyChanged(nameof(SectionName));
                }
            }
        }


        public String SectionName
        {
            get
            {
                return _monStudent.Section?.Name ?? "Section inconnue";
            }
            set
            {
                if (_monStudent.Section != null)
                {
                    _monStudent.Section.Name = value;
                    OnPropertyChanged("SectionName");
                }
            }
        }
        
    }
}
