using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.ViewModels
{
    public class ViewModelLocator
    {
        private ViewModels.MainPageViewModel mainPageViewModel;

        public ViewModels.MainPageViewModel MainPageViewModel
        {
            get
            {
                if (mainPageViewModel != null)
                {
                    return mainPageViewModel;
                }
                return mainPageViewModel = new MainPageViewModel();
            }
        }

        private ViewModels.AddMapPageViewModel addPageViewModel;

        public ViewModels.AddMapPageViewModel AddPageViewModel
        {
            get
            {
                if (addPageViewModel != null)
                {
                    return addPageViewModel;
                }
                return addPageViewModel = new AddMapPageViewModel();
            }
        }

        private ViewModels.TestViewModel testViewModel;

        public ViewModels.TestViewModel TestViewModel
        {
            get
            {
                if (testViewModel != null)
                {
                    return testViewModel;
                }
                return testViewModel = new TestViewModel();
            }
        }

        private ViewModels.InventoryPageViewModel inventoryPageViewModel;

        public ViewModels.InventoryPageViewModel InventoryPageViewModel
        {
            get
            {
                if (inventoryPageViewModel != null)
                {
                    return inventoryPageViewModel;
                }
                return inventoryPageViewModel = new InventoryPageViewModel();
            }
        }

        private ViewModels.OptionsPageViewModel optionsPageViewModel;

        public ViewModels.OptionsPageViewModel OptionsPageViewModel
        {
            get
            {
                if (optionsPageViewModel != null)
                {
                    return optionsPageViewModel;
                }
                return optionsPageViewModel = new OptionsPageViewModel();
            }
        }
    }
}
