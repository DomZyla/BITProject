using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDrivers.ViewModel
{
    public class SkillManagementViewModel
    {

        /// <summary>
        /// Private Properties
        /// </summary>
        private ObservableCollection<Skill> _skills;

        private Skill _selectedSkill;

        private RelayCommand _updateCommand;

        /// <summary>
        /// Public Properties
        /// </summary>
        public RelayCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(UpdateMethod, true);
                }
                return _updateCommand;
            }
            set
            {
                _updateCommand = value;
            }

        }

        /// <summary>
        /// Method for updating skills information
        /// </summary>
        public void UpdateMethod()
        {
            SelectedSkill.UpdateSkill();
            MessageBox.Show("Updated skill details successfully");
        }

        /// <summary>
        /// Gets the skills data for the datagrid
        /// </summary>
        public SkillManagementViewModel()
        {
            //Get the skills data from the db

            Skills = GetSkills();

        }

        /// <summary>
        /// Public Properties
        /// </summary>
        public ObservableCollection<Skill> Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
            }
        }

        public Skill SelectedSkill
        {
            get
            {
                return _selectedSkill;
            }
            set
            {
                _selectedSkill = value;
            }
        }

        public virtual ObservableCollection<Skill> GetSkills()
        {
            Skills allSkills = new Skills();

            ObservableCollection<Skill> skills = new ObservableCollection<Skill>(allSkills);
            return skills;
        }
    }
}
