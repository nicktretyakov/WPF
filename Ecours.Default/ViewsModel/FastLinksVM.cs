
using Ecours.Default.Model;
using Ecours.Default.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Ecours.Default.ViewModel
{
    public class FastLinksVM: BindableBase
    {

        private readonly ICommand showToolFastLinks_m;

        private readonly ICommand selectFastLink_m;

        private ObservableCollection<ImageButton> fastLinks_m;
        public ICommand ShowToolFastLinks { get { return showToolFastLinks_m; } }

        public ICommand SelectEcoursModule { get { return selectFastLink_m; } }

        private readonly FastLinksService fastLinksService_m = new FastLinksService();


        public ObservableCollection<ImageButton> FastLinks
        {
            get
            {
                return fastLinks_m;
            }
        }

        public ObservableCollection<EcoursModule> EcoursModules
        { 
            get
            {
                return new ObservableCollection<EcoursModule>(fastLinksService_m.EcoursModules);
            }            
        }

        public ObservableCollection<EcoursModule> SelectedEcoursModules
        {
            get
            {
                return new ObservableCollection<EcoursModule>(fastLinksService_m.SelectedEcoursModules);
            }
        }

        public FastLinksVM()
        {
            fastLinks_m = new ObservableCollection<ImageButton>();

            this.showToolFastLinks_m = new DelegateCommand<String>(this.OnShowToolFastLinks);

            this.selectFastLink_m = new DelegateCommand<object>(this.OnSelect);
            FillFastLinks();
        }

        private void FillFastLinks()
        {
            fastLinks_m.Clear();

            foreach (EcoursModule ecoursModule in fastLinksService_m.SelectedEcoursModules)
            {

                ImageButton imageButton = new ImageButton()
                {
                    Image = new BitmapImage(new Uri(@"/" + ecoursModule.Icon, UriKind.Relative)),
                    Content = ecoursModule.Name,
                    Style = Application.Current.FindResource("FastLinkStyle") as Style
                };

                fastLinks_m.Add(imageButton);
            }
        }

        public void OnSelect(object o)
        {          
            //fastLinksService_m.SelectEcoursModule((EcoursModulesTags)Enum.Parse(typeof(EcoursModulesTags), ecoursModule));
            fastLinksService_m.SelectEcoursModule((o as EcoursModule).Tag);
            RaisePropertyChanged("SelectedEcoursModules");
        }

        public void OnUnSelect(object o)
        {
            //fastLinksService_m.SelectEcoursModule((EcoursModulesTags)Enum.Parse(typeof(EcoursModulesTags), ecoursModule));
            fastLinksService_m.UnSelectEcoursModule((o as EcoursModule).Tag);
            RaisePropertyChanged("SelectedEcoursModules");
        }

        public void UpdateFastLinks()
        {        

            FillFastLinks();

        }

        public void OnShowToolFastLinks(String dlgName)
        {
            ToolFastLinkWidget dlg = DlgCreator.Create(dlgName) as ToolFastLinkWidget;

            dlg.ShowDialog(this);
                       


        }
    }
}
