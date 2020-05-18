using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Default.Model
{

    public enum EcoursModulesTags { ImpotantInfo,
                                        LegalAid,
                                      Dictionary,
                                       RenewDocs,
                                    LegalOpinion,
                                 LegalEduProgram,
                               ArbitragePractice,
                                          EnvLaw
    } 

    public class EcoursModule
    {
        private EcoursModulesTags tag_m;

        private String name_m;

        private String icon_m;

        public EcoursModulesTags Tag { get => tag_m; set => tag_m = value; }

        public String Name { get => name_m; set => name_m = value; }

        public String Icon { get => icon_m; set => icon_m = value; }

        public EcoursModule(EcoursModulesTags tag, String name, String icon)
        {
            tag_m = tag;

            name_m = name;

            icon_m = icon;
        }

    }

    public class FastLinksService: IFastLinksService
    {
        public IEnumerable<EcoursModule> EcoursModules;

        public List<EcoursModule> SelectedEcoursModules;

        public FastLinksService() {

            FillEcoursModules();

            SelectedEcoursModules = new List<EcoursModule>();

            SelectEcoursModule(EcoursModulesTags.ImpotantInfo);

            SelectEcoursModule(EcoursModulesTags.LegalAid);



        }

        private void FillEcoursModules()
        {
            EcoursModules = new List<EcoursModule>() {
                new EcoursModule(EcoursModulesTags.ImpotantInfo, "Важная информация", "Images/u3653.png"),
                new EcoursModule(EcoursModulesTags.LegalAid, "Юридическая помощь", "Images/u3650.png"),
                new EcoursModule(EcoursModulesTags.Dictionary, "Словарь", "Images/u3631.png"),
                new EcoursModule(EcoursModulesTags.RenewDocs, "Обновленные документы", "Images/u3656.png"),

                new EcoursModule(EcoursModulesTags.LegalOpinion, "Юридические заключения", "Images/u4464.png"),
                new EcoursModule(EcoursModulesTags.LegalEduProgram, "Правовой ликбез", "Images/u4467.png"),
                new EcoursModule(EcoursModulesTags.ArbitragePractice, "Судебная практика", "Images/u4470.png"),
                new EcoursModule(EcoursModulesTags.EnvLaw, "ЭкоПРАВО", "Images/u4489.png"),
            };
        }

        public void SelectEcoursModule(EcoursModulesTags selectedEcoursModule) {

            try
            {
                if (!SelectedEcoursModules.Any(m => m.Tag == selectedEcoursModule))

                    SelectedEcoursModules.Add(EcoursModules.Where(m => m.Tag == selectedEcoursModule).Single());

            }catch(InvalidOperationException ex)
            {
                throw new NotImplementedException();
            }
        }

        public void UnSelectEcoursModule(EcoursModulesTags selectedEcoursModule)
        {

            try
            {
                if (SelectedEcoursModules.Any(m => m.Tag == selectedEcoursModule))

                    SelectedEcoursModules.Remove(EcoursModules.Where(m => m.Tag == selectedEcoursModule).Single());

            }
            catch (InvalidOperationException ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
