using MVVMCrud.Core;
using MVVMCrud.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVVMCrud.UserInterface.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IUnitOfWork _unitOfWork;

        private List<Friend> _friends;
        public List<Friend> Friends
        {
            get { return _friends; }
            set
            {
                _friends = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private RelayCommand _loadDataCommand;
        public RelayCommand LoadDataCommand
        {
            get
            {
                return _loadDataCommand ??
                    (_loadDataCommand = new RelayCommand(
                        () => Friends = _unitOfWork.Friends.GetAll().ToList()));
            }
        }
    }
}