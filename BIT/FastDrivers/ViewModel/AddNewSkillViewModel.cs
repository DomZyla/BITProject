using FastDrivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDrivers.ViewModel
{
    public class AddNewSkillViewModel
    {

        /// <summary>
        /// Private Properties
        /// </summary>
        private Skill _skill;
        private RelayCommand _addCommand;


        /// <summary>
        /// Public Properties
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(AddMethod, true);
                }
                return _addCommand;
            }
            set
            {
                _addCommand = value;
            }
        }

        public AddNewSkillViewModel()
        {
            _skill = new Skill();
        }

        public Skill Skill
        {
            get
            {
                return _skill;
            }
            set
            {
                _skill = value;
            }
        }

        /// <summary>
        /// Add method for inserting a new skill
        /// </summary>
        public void AddMethod()
        {
            Skill.InsertSkill();
            MessageBox.Show("Skill inserted successfully");
        }
    }
}
