using exam012024.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApplication1.ViewModels;

namespace exam012024.ViewModels
{
    public class StudentVM
    {
        private SchoolContext dc = new SchoolContext();

  

        private StudentModel _selectedStudent;
        private SectionModel _selectedSection;

        private ObservableCollection<StudentModel> _StudentsList;
        private ObservableCollection<Section> _SectionsList;

        private DelegateCommand _addCommand;
        private DelegateCommand _saveCommand;

        public ObservableCollection<StudentModel> StudentsList
        {
            get
            {
                if (_StudentsList == null)
                {
                    _StudentsList = loadStudents();
                }
                return _StudentsList;

            }

        }

        public ObservableCollection<Section> SectionsList
        {
            get
            {
                if (_SectionsList == null)
                {
                    _SectionsList = loadSections();
                }
                return _SectionsList;

            }

        }

        private ObservableCollection<StudentModel> loadStudents()
        {
            ObservableCollection<StudentModel> localCollection = new ObservableCollection<StudentModel>();
            foreach (var item in dc.Students)
            {
                localCollection.Add(new StudentModel(item));

            }

            return localCollection;

        }

        private ObservableCollection<Section> loadSections()
        {
            ObservableCollection<Section> localCollection = new ObservableCollection<Section>();
            foreach (var item in dc.Sections)
            {
                localCollection.Add(item);

            }

            return localCollection;
        }


        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value; }

        }

        public DelegateCommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new DelegateCommand(SaveStudent); }
        }

        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand = _addCommand ?? new DelegateCommand(AddStudent);
            }

        }

        private void AddStudent()
        {
            Student EGlobal = new Student();
            StudentModel EModel = new StudentModel(EGlobal);
            StudentsList.Add(EModel);
            SelectedStudent = EModel;
        }

        private void SaveStudent()
        {
            if (SelectedStudent?.MonStudent == null)
            {
                MessageBox.Show("Selected student is null");
                return;
            }
            Student verif = dc.Students.Where(e => e.StudentId == SelectedStudent.MonStudent.StudentId).SingleOrDefault();
            if (verif == null)
            {
                dc.Students.Add(SelectedStudent.MonStudent);
            }
            dc.SaveChanges();
            MessageBox.Show("Enregistrement en base de données fait");
        }
 

}
}
