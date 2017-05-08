using MVVMCrud.Core;
using MVVMCrud.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Tynamix.ObjectFiller;

namespace MVVMCrud.UserInterface.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IUnitOfWork _unitOfWork;

        private ObservableCollection<Friend> _friends;
        public ObservableCollection<Friend> Friends
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
                        () => Friends = new ObservableCollection<Friend>(_unitOfWork.Friends.GetAll())));
            }
        }

        private RelayCommand _addSomeFriendsCommand;
        public RelayCommand AddSomeFriendsCommand
        {
            get
            {
                return _addSomeFriendsCommand ??
                    (_addSomeFriendsCommand = new RelayCommand(
                        () =>
                        {
                            var friendFiller = new Filler<Friend>();
                            friendFiller.Setup()
                                .OnProperty(f => f.Id).IgnoreIt()
                                .OnProperty(f => f.Firstname).Use(new RealNames(NameStyle.FirstName))
                                .OnProperty(f => f.Lastname).Use(new RealNames(NameStyle.LastName))
                                .OnProperty(f => f.BirthDate).Use(new DateTimeRange(DateTime.Now.AddYears(50), DateTime.Now.AddYears(15)));

                            // Create some sample Friends and add them.
                            var friends = friendFiller.Create(20);

                            // Refresh the Friends that are displayed.
                            foreach (var friend in friends)
                            {
                                Friends.Add(friend);
                            }
                        }));
            }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new RelayCommand(
                        () =>
                        {
                            var newFriends = Friends.Where(f => f.Id == 0);
                            _unitOfWork.Friends.AddRange(newFriends);

                            _unitOfWork.Complete();
                        }));
            }
        }
    }
}