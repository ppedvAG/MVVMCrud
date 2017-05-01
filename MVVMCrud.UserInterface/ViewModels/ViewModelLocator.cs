using MVVMCrud.Core;
using MVVMCrud.Data.EF;
using StructureMap;

namespace MVVMCrud.UserInterface.ViewModels
{
    internal class ViewModelLocator
    {
        private readonly Container _container;

        public MainWindowViewModel Main
        {
            get { return _container.GetInstance<MainWindowViewModel>(); }
        }

        public ViewModelLocator()
        {
            _container = new Container(config =>
            {
                config.For<IUnitOfWork>().Use<UnitOfWork>();
            }); 
        }
    }
}
