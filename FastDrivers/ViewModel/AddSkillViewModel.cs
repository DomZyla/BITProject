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
    public class AddSkillViewModel
    {

        /// <summary>
        /// Private Properties
        /// </summary>
        private ObservableCollection<ContractorSkill> _contractorSkills;

        private ObservableCollection<ContractorSkill> _currentSkills;

        private ContractorSkill _selectedContractorSkill;

        private RelayCommand _assignCommand;

        private Contractor _selectedContractor;

        private RelayCommand _deleteCommand;


        /// <summary>
        /// Public Properties 
        /// </summary>
        public RelayCommand AssignCommand
        {
            get
            {
                if (_assignCommand == null)
                {
                    _assignCommand = new RelayCommand(AssignMethod, true);
                }
                return _assignCommand;
            }
            set
            {
                _assignCommand = value;
            }

        }

        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(DeleteMethod, true);
                }
                return _deleteCommand;
            }
            set
            {
                _deleteCommand = value;
            }

        }

        /// <summary>
        /// Method for removing a skill from a contractor
        /// </summary>
        public void DeleteMethod()
        {
            SelectedContractorSkill.DeleteContractorSkill();
        }

        /// <summary>
        /// Method for assigning a skill to a contractor
        /// </summary>
        public void AssignMethod()
        {
            ContractorSkill cs = new ContractorSkill();
            cs.SkillId = SelectedContractorSkill.SkillId;
            cs.ContractorId = SelectedContractor.ContractorId;
            cs.AssignSkill();
        }

        public AddSkillViewModel()
        {
            //Get the skills data from the db

            //ContractorSkills = GetContractorSkills();

        }

        /// <summary>
        /// Public Properties
        /// </summary>
        public ObservableCollection<ContractorSkill> ContractorSkills
        {
            get
            {
                return _contractorSkills;
            }
            set
            {
                _contractorSkills = value;
            }
        }

        public ObservableCollection<ContractorSkill> CurrentSkills
        {
            get
            {
                return _currentSkills;
            }
            set
            {
                _currentSkills = value;
            }
        }

        public ContractorSkill SelectedContractorSkill
        {
            get
            {
                return _selectedContractorSkill;
            }
            set
            {
                _selectedContractorSkill = value;
            }
        }

        public Contractor SelectedContractor
        {
            get
            {
                return _selectedContractor;
            }
            set
            {
                _selectedContractor = value;
            }
        }

        public ObservableCollection<ContractorSkill> GetContractorSkills(Contractor contractor)
        {
            ContractorSkills allContractorSkills = new ContractorSkills(contractor);

            ObservableCollection<ContractorSkill> contractorSkills = new ObservableCollection<ContractorSkill>(allContractorSkills);
            return contractorSkills;
        }

        public ObservableCollection<ContractorSkill> GetCurrentSkills(Contractor contractor)
        {
            CurrentSkills allCurrentSkills = new CurrentSkills(contractor);

            ObservableCollection<ContractorSkill> currentSkills = new ObservableCollection<ContractorSkill>(allCurrentSkills);
            return currentSkills;
        }

        /// <summary>
        /// Parses all needed data and gets information from the database for contractors and skills
        /// </summary>
        /// <param name="contractor"></param>
        public AddSkillViewModel(Contractor contractor)
        {
            SelectedContractor = contractor;
            ContractorSkills = GetContractorSkills(contractor);
            CurrentSkills = GetCurrentSkills(contractor);
        }
    }
}
