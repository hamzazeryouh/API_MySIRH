
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Presistence.DataContext;
using API_MySIRH.Application.Data;
using API_MySIRH.Application.DataInteraction.DataAccess;
using API_MySIRH.Application.DataInteraction.DataAccess.Base;
using API_MySIRH.Application.DataInteraction.Generals;
using API_MySIRH.Domain.Interfaces;


namespace API_MySIRH.Presistence
{
    using global::Presistence;
    using API_MySIRH.DataAccess;
    using API_MySIRH.Presistence.DataContext;
    using System;
    using System.Collections;
    using System.Linq;
    using System.Threading.Tasks;
    public class UnitOfWork : IUnitOfWork
    {
        private readonly API_MySIRHDbContext _dbContext;

        private Hashtable _repositories;
        private Hashtable _repositoriesWithKey;
        private IAccountDataAccess _accountDataAccess;
        private IRoleDataAccess _roleDataAccess;


        private readonly ILoggerFactory _loggerFactory;

        private IFluprojetDataAccess _FLuProjectDataAccess;
        private ILstimagetypeDataAccess _LstimagetypeDataAccess;
        private IFluimageDataAccess _FluimageDataAccess ;
        private IAssprojetinterventionDataAccess _AssprojetinterventionDataAccess ;
        private IAssIntervenantsecteurDataAccess _AssintervenantsecteurDataAccess ;
        private IAssintervenantuserDataAccess _AssintervenantuserDataAccess ;
        private IAssinterventionequipeDataAccess _AssinterventionequipeDataAccess ;
        private IFluintervenantDataAccess _FluintervenantDataAccess ;
        private IFluinterventionDataAccess _FluinterventionDataAccess ;
        private IFlumarcheprojetDataAccess _FlumarcheprojetDataAccess ;
        private IFlumesureintensiteDataAccess _FlumesureintensiteDataAccess ;
        private IFluprojetactionDataAccess _FluprojetactionDataAccess ;
        private IFluProjetavancementDataAccess _FluprojetavancementDataAccess ;
        private IFluProjetdetailDataAccess _FluprojetdetailDataAccess ;
        private IFluprojetDataAccess _FluprojetDataAccess ;
        IFlurelevecompteurDataAccess _FlurelevecompteurDataAccess ;
        private IFlutourneeDataAccess _FlutourneeDataAccess ;
        private ILstouvragetypeDataAccess _LstouvragetypeDataAccess ;
        private ISpaarmoireDataAccess _SpaarmoireDataAccess ;
        private ISpadepartDataAccess _SpadepartDataAccess ;
        private ISpaitineraireDataAccess _SpaitineraireDataAccess ;
        private ISpaouvragecabDataAccess _SpaouvragecabDataAccess ;
        private ISpaouvragelumDataAccess _SpaouvragelumDataAccess ;
        private ISpaouvrageDataAccess _SpaouvrageDataAccess ;
        private ISpasecteurDataAccess _SpasecteurDataAccess ;
        private IAssprojetdetailsfamDataAccess _AssprojetdetailsfamDataAccess ;

        public ISupPortqrDataAccess _SupportqrDataAccess;



       public IFluprojetDataAccess FluProjetDataAccess
        {
            get
            {
                if (_FLuProjectDataAccess is null)
                    _FLuProjectDataAccess = new FluprojetDataAccess(_dbContext, _loggerFactory);

                return _FLuProjectDataAccess;
            }
        }



        public IFluimageDataAccess FluimageDataAccess 
        {
            get
            {
                if (_FluimageDataAccess is null)
                    _FluimageDataAccess = new FluimageDataAccess(_dbContext, _loggerFactory);

                return _FluimageDataAccess;
            }
        }



        public IAssIntervenantsecteurDataAccess AssintervenantsecteurDataAccess
        {
            get
            {
                if (_AssintervenantsecteurDataAccess is null)
                    _AssintervenantsecteurDataAccess = new AssIntervenantsecteurDataAccess(_dbContext, _loggerFactory);

                return _AssintervenantsecteurDataAccess;
            }
        }

        public IAssintervenantuserDataAccess AssintervenantuserDataAccess
        {
            get
            {
                if (_AssintervenantuserDataAccess is null)
                    _AssintervenantuserDataAccess = new AssintervenantuserDataAccess(_dbContext, _loggerFactory);

                return _AssintervenantuserDataAccess;
            }
        }

        public IAssinterventionequipeDataAccess AssinterventionequipeDataAccess
        {
            get
            {
                if (_AssinterventionequipeDataAccess is null)
                    _AssinterventionequipeDataAccess = new AssinterventionequipeDataAccess(_dbContext, _loggerFactory);

                return _AssinterventionequipeDataAccess;
            }
        }

        public IFluintervenantDataAccess FluintervenantDataAccess
        {
            get
            {
                if (_FluintervenantDataAccess is null)
                    _FluintervenantDataAccess = new FluintervenantDataAccess(_dbContext, _loggerFactory);

                return _FluintervenantDataAccess;
            }
        }

        public IFluinterventionDataAccess FluinterventionDataAccess
        {
            get
            {
                if (_FluinterventionDataAccess is null)
                    _FluinterventionDataAccess = new FluinterventionDataAccess(_dbContext, _loggerFactory);

                return _FluinterventionDataAccess;
            }
        }


        public IFlumarcheprojetDataAccess FlumarcheprojetDataAccess
        {
            get
            {
                if (_FlumarcheprojetDataAccess is null)
                    _FlumarcheprojetDataAccess = new FlumarcheprojetDataAccess(_dbContext, _loggerFactory);

                return _FlumarcheprojetDataAccess;
            }
        }

        public IFlumesureintensiteDataAccess FlumesureintensiteDataAccess
        {
            get
            {
                if (_FlumesureintensiteDataAccess is null)
                    _FlumesureintensiteDataAccess = new FlumesureintensiteDataAccess(_dbContext, _loggerFactory);

                return _FlumesureintensiteDataAccess;
            }
        }

        public IFluprojetactionDataAccess FluprojetactionDataAccess
        {
            get
            {
                if (_FluprojetactionDataAccess is null)
                    _FluprojetactionDataAccess = new FluprojetactionDataAccess(_dbContext, _loggerFactory);

                return _FluprojetactionDataAccess;
            }
        }

        public IFluProjetavancementDataAccess FluprojetavancementDataAccess
        {
            get
            {
                if (_FluprojetavancementDataAccess is null)
                    _FluprojetavancementDataAccess = new FluprojetavancementDataAccess(_dbContext, _loggerFactory);

                return _FluprojetavancementDataAccess;
            }
        }

        public IFluProjetdetailDataAccess FluprojetdetailDataAccess
        {
            get
            {
                if (_FluprojetdetailDataAccess is null)
                    _FluprojetdetailDataAccess = new FluProjetdetailDataAccess(_dbContext, _loggerFactory);
               
                return _FluprojetdetailDataAccess;
            }
        }

        public IFluprojetDataAccess FluprojetDataAccess
        {
            get
            {
                if (_FluprojetDataAccess is null)
                    _FluprojetDataAccess = new FluprojetDataAccess(_dbContext, _loggerFactory);

                return _FluprojetDataAccess;
            }
        }


        public IFlutourneeDataAccess FlutourneeDataAccess
        {
            get
            {
                if (_FlutourneeDataAccess is null)
                    _FlutourneeDataAccess = new FlutourneeDataAccess(_dbContext, _loggerFactory);

                return _FlutourneeDataAccess;
            }
        }


        //public IFluUserwebDataAccess FluuserwebDataAccess
        //{
        //    get
        //    {
        //        if (_FluuserwebDataAccess is null)
        //            _FluuserwebDataAccess = new FluUserwebDataAccess(_dbContext, _loggerFactory);

        //        return _FluuserwebDataAccess;
        //    }
        //}

        public ISpaarmoireDataAccess SpaarmoireDataAccess
        {
            get
            {
                if (_SpaarmoireDataAccess is null)
                    _SpaarmoireDataAccess = new SpaarmoireDataAccess(_dbContext, _loggerFactory);

                return _SpaarmoireDataAccess;
            }
        }

        public ISpadepartDataAccess SpadepartDataAccess
        {
            get
            {
                if (_SpadepartDataAccess is null)
                    _SpadepartDataAccess = new SpadepartDataAccess(_dbContext, _loggerFactory);

                return _SpadepartDataAccess;
            }
        }

        public ISpaitineraireDataAccess SpaitineraireDataAccess
        {
            get
            {
                if (_SpaitineraireDataAccess is null)
                    _SpaitineraireDataAccess = new SpaitineraireDataAccess(_dbContext, _loggerFactory);

                return _SpaitineraireDataAccess;
            }
        }

        public ISpaouvragecabDataAccess SpaouvragecabDataAccess
        {
            get
            {
                if (_SpaouvragecabDataAccess is null)
                    _SpaouvragecabDataAccess = new SpaouvragecabDataAccess(_dbContext, _loggerFactory);

                return _SpaouvragecabDataAccess;
            }
        }

        public ISpaouvragelumDataAccess SpaouvragelumDataAccess
        {
            get
            {
                if (_SpaouvragelumDataAccess is null)
                    _SpaouvragelumDataAccess = new SpaouvragelumDataAccess(_dbContext, _loggerFactory);

                return _SpaouvragelumDataAccess;
            }
        }

        public ISpaouvrageDataAccess SpaouvrageDataAccess
        {
            get
            {
                if (_SpaouvrageDataAccess is null)
                    _SpaouvrageDataAccess = new SpaouvrageDataAccess(_dbContext, _loggerFactory);

                return _SpaouvrageDataAccess;
            }
        }

        public ISpasecteurDataAccess SpasecteurDataAccess
        {
            get
            {
                if (_SpasecteurDataAccess is null)
                    _SpasecteurDataAccess = new SpasecteurDataAccess(_dbContext, _loggerFactory);

                return _SpasecteurDataAccess;
            }
        }

        public IAssprojetdetailsfamDataAccess AssprojetdetailsfamDataAccess
        {
            get
            {
                if (_AssprojetdetailsfamDataAccess is null)
                    _AssprojetdetailsfamDataAccess = new AssprojetdetailsfamDataAccess(_dbContext, _loggerFactory);

                return _AssprojetdetailsfamDataAccess;
            }
        }

        public IAssprojetinterventionDataAccess AssprojetinterventionDataAccess
        {
            get
            {
                if (_AssprojetinterventionDataAccess is null)
                    _AssprojetinterventionDataAccess = new AssprojetinterventionDataAccess(_dbContext, _loggerFactory);

                return _AssprojetinterventionDataAccess;
            }
        }



        public IFlurelevecompteurDataAccess FlurelevecompteurDataAccess
        {
            get
            {
                if (_FlurelevecompteurDataAccess is null)
                    _FlurelevecompteurDataAccess = new FlurelevecompteurDataAccess(_dbContext, _loggerFactory);

                return _FlurelevecompteurDataAccess;
            }
        }

       
        public ISpaterrainpositionDataAccess _SpaterrainpositionDataAccess;
        public ISpaterrainpositionDataAccess SpaterrainpositionDataAccess
        {
            get
            {
                if (_SpaterrainpositionDataAccess is null)
                    _SpaterrainpositionDataAccess = new SpaterrainpositionDataAccess(_dbContext, _loggerFactory);

                return _SpaterrainpositionDataAccess;
            }
        }
        public ISpavoieDataAccess _SpavoieDataAccess;
        public ISpavoieDataAccess SpavoieDataAccess
        {
            get
            {
                if (_SpavoieDataAccess is null)
                    _SpavoieDataAccess = new SpavoieDataAccess(_dbContext, _loggerFactory);

                return _SpavoieDataAccess;
            }
        }
        public ILsttypearmoireDataAccess _LsttypearmoireDataAccess;
        public ILsttypearmoireDataAccess LsttypearmoireDataAccess
        {
            get
            {
                if (_LsttypearmoireDataAccess is null)
                    _LsttypearmoireDataAccess = new LsttypearmoireDataAccess(_dbContext, _loggerFactory);

                return _LsttypearmoireDataAccess;
            }
        }
        public ILstsupportDataAccess _LstsupportDataAccess;
        public ILstsupportDataAccess LstsupportDataAccess
        {
            get
            {
                if (_LstsupportDataAccess is null)
                    _LstsupportDataAccess = new LstsupportDataAccess(_dbContext, _loggerFactory);

                return _LstsupportDataAccess;
            }
        }
        public ILstsupportfamDataAccess _LstsupportfamDataAccess;
        public ILstsupportfamDataAccess LstsupportfamDataAccess
        {
            get
            {
                if (_LstsupportfamDataAccess is null)
                    _LstsupportfamDataAccess = new LstsupportfamDataAccess(_dbContext, _loggerFactory);

                return _LstsupportfamDataAccess;
            }
        }
        public ILstreportDataAccess _LstreportDataAccess;
        public ILstreportDataAccess LstreportDataAccess
        {
            get
            {
                if (_LstreportDataAccess is null)
                    _LstreportDataAccess = new LstreportDataAccess(_dbContext, _loggerFactory);

                return _LstreportDataAccess;
            }
        }
        public ILstprofilDataAccess _LstprofilDataAccess;
        public ILstprofilDataAccess LstprofilDataAccess
        {
            get
            {
                if (_LstprofilDataAccess is null)
                    _LstprofilDataAccess = new LstprofilDataAccess(_dbContext, _loggerFactory);

                return _LstprofilDataAccess;
            }
        }
        public ILstprojetcatDataAccess _LstprojetcatDataAccess;
        public ILstprojetcatDataAccess LstprojetcatDataAccess
        {
            get
            {
                if (_LstprojetcatDataAccess is null)
                    _LstprojetcatDataAccess = new LstprojetcatDataAccess(_dbContext, _loggerFactory);

                return _LstprojetcatDataAccess;
            }
        }
        public ILstprojetfamDataAccess _LstprojetfamDataAccess;
        public ILstprojetfamDataAccess LstprojetfamDataAccess
        {
            get
            {
                if (_LstprojetfamDataAccess is null)
                    _LstprojetfamDataAccess = new LstprojetfamDataAccess(_dbContext, _loggerFactory);

                return _LstprojetfamDataAccess;
            }
        }
        public ILstproprietaireDataAccess _LstproprietaireDataAccess;
        public ILstproprietaireDataAccess LstproprietaireDataAccess
        {
            get
            {
                if (_LstproprietaireDataAccess is null)
                    _LstproprietaireDataAccess = new LstproprietaireDataAccess(_dbContext, _loggerFactory);

                return _LstproprietaireDataAccess;
            }
        }
        public ILstregimeDataAccess _LstregimeDataAccess;
        public ILstregimeDataAccess LstregimeDataAccess
        {
            get
            {
                if (_LstregimeDataAccess is null)
                    _LstregimeDataAccess = new LstregimeDataAccess(_dbContext, _loggerFactory);

                return _LstregimeDataAccess;
            }
        }
        public ILstvoiedomDataAccess _LstvoiedomDataAccess;
        public ILstvoiedomDataAccess LstvoiedomDataAccess
        {
            get
            {
                if (_LstvoiedomDataAccess is null)
                    _LstvoiedomDataAccess = new LstvoiedomDataAccess(_dbContext, _loggerFactory);

                return _LstvoiedomDataAccess;
            }
        }
        public ILstprojetsfamDataAccess _LstprojetsfamDataAccess;
        public ILstprojetsfamDataAccess LstprojetsfamDataAccess
        {
            get
            {
                if (_LstprojetsfamDataAccess is null)
                    _LstprojetsfamDataAccess = new LstprojetsfamDataAccess(_dbContext, _loggerFactory);

                return _LstprojetsfamDataAccess;
            }
        }
        public ILstreponseDataAccess _LstreponseDataAccess;
        public ILstreponseDataAccess LstreponseDataAccess
        {
            get
            {
                if (_LstreponseDataAccess is null)
                    _LstreponseDataAccess = new LstreponseDataAccess(_dbContext, _loggerFactory);

                return _LstreponseDataAccess;
            }
        }
        public ILsttarifDataAccess _LsttarifDataAccess;
        public ILsttarifDataAccess LsttarifDataAccess
        {
            get
            {
                if (_LsttarifDataAccess is null)
                    _LsttarifDataAccess = new LsttarifDataAccess(_dbContext, _loggerFactory);

                return _LsttarifDataAccess;
            }
        }
        public ILstinterventiontypeDataAccess _LstinterventiontypeDataAccess;
        public ILstinterventiontypeDataAccess LstinterventiontypeDataAccess
        {
            get
            {
                if (_LstinterventiontypeDataAccess is null)
                    _LstinterventiontypeDataAccess = new LstinterventiontypeDataAccess(_dbContext, _loggerFactory);

                return _LstinterventiontypeDataAccess;
            }
        }
        public ILstcorrespondantDataAccess _LstcorrespondantDataAccess;
        public ILstcorrespondantDataAccess LstcorrespondantDataAccess
        {
            get
            {
                if (_LstcorrespondantDataAccess is null)
                    _LstcorrespondantDataAccess = new LstcorrespondantDataAccess(_dbContext, _loggerFactory);

                return _LstcorrespondantDataAccess;
            }
        }
        public ILstavancementDataAccess _LstavancementDataAccess;
        public ILstavancementDataAccess LstavancementDataAccess
        {
            get
            {
                if (_LstavancementDataAccess is null)
                    _LstavancementDataAccess = new LstavancementDataAccess(_dbContext, _loggerFactory);

                return _LstavancementDataAccess;
            }
        }
        public IHisrojetassociationsysDataAccess _HisrojetassociationsysDataAccess;
        public IHisrojetassociationsysDataAccess HisrojetassociationsysDataAccess
        {
            get
            {
                if (_HisrojetassociationsysDataAccess is null)
                    _HisrojetassociationsysDataAccess = new HisrojetassociationsysDataAccess(_dbContext, _loggerFactory);

                return _HisrojetassociationsysDataAccess;
            }
        }
        public IHisterrainlogmajDataAccess _HisterrainlogmajDataAccess;
        public IHisterrainlogmajDataAccess HisterrainlogmajDataAccess
        {
            get
            {
                if (_HisterrainlogmajDataAccess is null)
                    _HisterrainlogmajDataAccess = new HisterrainlogmajDataAccess(_dbContext, _loggerFactory);

                return _HisterrainlogmajDataAccess;
            }
        }
        public IHisregimejourDataAccess _HisregimejourDataAccess;
        public IHisregimejourDataAccess HisregimejourDataAccess
        {
            get
            {
                if (_HisregimejourDataAccess is null)
                    _HisregimejourDataAccess = new HisregimejourDataAccess(_dbContext, _loggerFactory);

                return _HisregimejourDataAccess;
            }
        }
        public IHisprojetouvrageDataAccess _HisprojetouvrageDataAccess;
        public IHisprojetouvrageDataAccess HisprojetouvrageDataAccess
        {
            get
            {
                if (_HisprojetouvrageDataAccess is null)
                    _HisprojetouvrageDataAccess = new HisprojetouvrageDataAccess(_dbContext, _loggerFactory);

                return _HisprojetouvrageDataAccess;
            }
        }
        public IHisprojetouvragelumDataAccess _HisprojetouvragelumDataAccess;
        public IHisprojetouvragelumDataAccess HisprojetouvragelumDataAccess
        {
            get
            {
                if (_HisprojetouvragelumDataAccess is null)
                    _HisprojetouvragelumDataAccess = new HisprojetouvragelumDataAccess(_dbContext, _loggerFactory);

                return _HisprojetouvragelumDataAccess;
            }
        }
        public IHisversionDataAccess _HisversionDataAccess;
        public IHisversionDataAccess HisversionDataAccess
        {
            get
            {
                if (_HisversionDataAccess is null)
                    _HisversionDataAccess = new HisversionDataAccess(_dbContext, _loggerFactory);

                return _HisversionDataAccess;
            }
        }
        public IHisprojetouvragecabDataAccess _HisprojetouvragecabDataAccess;
        public IHisprojetouvragecabDataAccess HisprojetouvragecabDataAccess
        {
            get
            {
                if (_HisprojetouvragecabDataAccess is null)
                    _HisprojetouvragecabDataAccess = new HisprojetouvragecabDataAccess(_dbContext, _loggerFactory);

                return _HisprojetouvragecabDataAccess;
            }
        }
        public IHisprojetarmoireDataAccess _HisprojetarmoireDataAccess;
        public IHisprojetarmoireDataAccess HisprojetarmoireDataAccess
        {
            get
            {
                if (_HisprojetarmoireDataAccess is null)
                    _HisprojetarmoireDataAccess = new HisprojetarmoireDataAccess(_dbContext, _loggerFactory);

                return _HisprojetarmoireDataAccess;
            }
        }
        public IHisprojetchangeobjDataAccess _HisprojetchangeobjDataAccess;
        public IHisprojetchangeobjDataAccess HisprojetchangeobjDataAccess
        {
            get
            {
                if (_HisprojetchangeobjDataAccess is null)
                    _HisprojetchangeobjDataAccess = new HisprojetchangeobjDataAccess(_dbContext, _loggerFactory);

                return _HisprojetchangeobjDataAccess;
            }
        }
        public IHisconnecthistoDataAccess _HisconnecthistoDataAccess;
        public IHisconnecthistoDataAccess HisconnecthistoDataAccess
        {
            get
            {
                if (_HisconnecthistoDataAccess is null)
                    _HisconnecthistoDataAccess = new HisconnecthistoDataAccess(_dbContext, _loggerFactory);

                return _HisconnecthistoDataAccess;
            }
        }
        public IHisintervenantuserDataAccess _HisintervenantuserDataAccess;
        public IHisintervenantuserDataAccess HisintervenantuserDataAccess
        {
            get
            {
                if (_HisintervenantuserDataAccess is null)
                    _HisintervenantuserDataAccess = new HisintervenantuserDataAccess(_dbContext, _loggerFactory);

                return _HisintervenantuserDataAccess;
            }
        }


        public ILstoperationDataAccess _LstoperationDataAccess;

        public ILstoperationDataAccess LstoperationDataAccess
        {
            get
            {
                if (_LstoperationDataAccess is null)
                    _LstoperationDataAccess = new LstoperationDataAccess(_dbContext, _loggerFactory);

                return _LstoperationDataAccess;
            }
        }
        public ILstmoyenDataAccess _LstmoyenDataAccess;
        public ILstmoyenDataAccess LstmoyenDataAccess
        {
            get
            {
                if (_LstmoyenDataAccess is null)
                    _LstmoyenDataAccess = new LstmoyenDataAccess(_dbContext, _loggerFactory);

                return _LstmoyenDataAccess;
            }
        }
        public ILstluminairefonctionDataAccess _LstluminairefonctionDataAccess;
        public ILstluminairefonctionDataAccess LstluminairefonctionDataAccess
        {
            get
            {
                if (_LstluminairefonctionDataAccess is null)
                    _LstluminairefonctionDataAccess = new LstluminairefonctionDataAccess(_dbContext, _loggerFactory);

                return _LstluminairefonctionDataAccess;
            }
        }
        public ILstnatureDataAccess _LstnatureDataAccess;
        public ILstnatureDataAccess LstnatureDataAccess
        {
            get
            {
                if (_LstnatureDataAccess is null)
                    _LstnatureDataAccess = new LstnatureDataAccess(_dbContext, _loggerFactory);

                return _LstnatureDataAccess;
            }
        }


        public ILstluminairefamDataAccess _LstluminairefamDataAccess;
        public ILstluminairefamDataAccess LstluminairefamDataAccess
        {
            get
            {
                if (_LstluminairefamDataAccess is null)
                    _LstluminairefamDataAccess = new LstluminairefamDataAccess(_dbContext, _loggerFactory);

                return _LstluminairefamDataAccess;
            }
        }

        public ILstluminaireDataAccess _LstluminaireDataAccess;
        public ILstluminaireDataAccess LstluminaireDataAccess
        {
            get
            {
                if (_LstluminaireDataAccess is null)
                    _LstluminaireDataAccess = new LstluminaireDataAccess(_dbContext, _loggerFactory);

                return _LstluminaireDataAccess;
            }
        }

        public ILstlampefamDataAccess _LstlampefamDataAccess;
        public ILstlampefamDataAccess LstlampefamDataAccess
        {
            get
            {
                if (_LstlampefamDataAccess is null)
                    _LstlampefamDataAccess = new LstlampefamDataAccess(_dbContext, _loggerFactory);

                return _LstlampefamDataAccess;
            }
        }

        public ILstlappareilfamDataAccess _LstlappareilfamDataAccess;
        public ILstlappareilfamDataAccess LstlappareilfamDataAccess
        {
            get
            {
                if (_LstlappareilfamDataAccess is null)
                    _LstlappareilfamDataAccess = new LstlappareilfamDataAccess(_dbContext, _loggerFactory);

                return _LstlappareilfamDataAccess;
            }
        }
        public ILstlampeDataAccess _LstlampeDataAccess;
        public ILstlampeDataAccess LstlampeDataAccess
        {
            get
            {
                if (_LstlampeDataAccess is null)
                    _LstlampeDataAccess = new LstlampeDataAccess(_dbContext, _loggerFactory);

                return _LstlampeDataAccess;
            }
        }
        public ILstfournisseurDataAccess _LstfournisseurDataAccess;
        public ILstfournisseurDataAccess LstfournisseurDataAccess
        {
            get
            {
                if (_LstfournisseurDataAccess is null)
                    _LstfournisseurDataAccess = new LstfournisseurDataAccess(_dbContext, _loggerFactory);

                return _LstfournisseurDataAccess;
            }
        }
        public ILstentrepriseDataAccess _LstentrepriseDataAccess;
        public ILstentrepriseDataAccess LstentrepriseDataAccess
        {
            get
            {
                if (_LstentrepriseDataAccess is null)
                    _LstentrepriseDataAccess = new LstentrepriseDataAccess(_dbContext, _loggerFactory);

                return _LstentrepriseDataAccess;
            }
        }

        public ILstactionDataAccess _LstactionDataAccess;
        public ILstactionDataAccess LstactionDataAccess
        {
            get
            {
                if (_LstactionDataAccess is null)
                    _LstactionDataAccess = new LstactionDataAccess(_dbContext, _loggerFactory);

                return _LstactionDataAccess;
            }
        }
        public ILstcableDataAccess _LstcableDataAccess;
        public ILstcableDataAccess LstcableDataAccess
        {
            get
            {
                if (_LstcableDataAccess is null)
                    _LstcableDataAccess = new LstcableDataAccess(_dbContext, _loggerFactory);

                return _LstcableDataAccess;
            }
        }
        public ILstcablefamDataAccess _LstcablefamDataAccess;
        public ILstcablefamDataAccess LstcablefamDataAccess
        {
            get
            {
                if (_LstcablefamDataAccess is null)
                    _LstcablefamDataAccess = new LstcablefamDataAccess(_dbContext, _loggerFactory);

                return _LstcablefamDataAccess;
            }
        }
        public ILstcauseDataAccess _LstcauseDataAccess;
        public ILstcauseDataAccess LstcauseDataAccess
        {
            get
            {
                if (_LstcauseDataAccess is null)
                    _LstcauseDataAccess = new LstcauseDataAccess(_dbContext, _loggerFactory);

                return _LstcauseDataAccess;
            }
        }
        public ILstcentrefacturationDataAccess _LstcentrefacturationDataAccess;
        public ILstcentrefacturationDataAccess LstcentrefacturationDataAccess
        {
            get
            {
                if (_LstcentrefacturationDataAccess is null)
                    _LstcentrefacturationDataAccess = new LstcentrefacturationDataAccess(_dbContext, _loggerFactory);

                return _LstcentrefacturationDataAccess;
            }
        }

        public ILstconsoleDataAccess _LstconsoleDataAccess;
        public ILstconsoleDataAccess LstconsoleDataAccess
        {
            get
            {
                if (_LstconsoleDataAccess is null)
                    _LstconsoleDataAccess = new LstconsoleDataAccess(_dbContext, _loggerFactory);

                return _LstconsoleDataAccess;
            }
        }
        public ILstconsolefamDataAccess _LstconsolefamDataAccess;
        public ILstconsolefamDataAccess LstconsolefamDataAccess
        {
            get
            {
                if (_LstconsolefamDataAccess is null)
                    _LstconsolefamDataAccess = new LstconsolefamDataAccess(_dbContext, _loggerFactory);

                return _LstconsolefamDataAccess;
            }
        }
        public ILstdelaidepanDataAccess _LstdelaidepanDataAccess;
        public ILstdelaidepanDataAccess LstdelaidepanDataAccess
        {
            get
            {
                if (_LstdelaidepanDataAccess is null)
                    _LstdelaidepanDataAccess = new LstdelaidepanDataAccess(_dbContext, _loggerFactory);

                return _LstdelaidepanDataAccess;
            }
        }

        public ILstdomaineDataAccess _LstdomaineDataAccess;
        public ILstdomaineDataAccess LstdomaineDataAccess
        {
            get
            {
                if (_LstdomaineDataAccess is null)
                    _LstdomaineDataAccess = new LstdomaineDataAccess(_dbContext, _loggerFactory);

                return _LstdomaineDataAccess;
            }
        }
        public ILstdrtypeDataAccess _LstdrtypeDataAccess;
        public ILstdrtypeDataAccess LstdrtypeDataAccess
        {
            get
            {
                if (_LstdrtypeDataAccess is null)
                    _LstdrtypeDataAccess = new LstdrtypeDataAccess(_dbContext, _loggerFactory);

                return _LstdrtypeDataAccess;
            }
        }
        public ILstanomalieDataAccess _LstanomalieDataAccess;
        public ILstanomalieDataAccess LstanomalieDataAccess
        {
            get
            {
                if (_LstanomalieDataAccess is null)
                    _LstanomalieDataAccess = new LstanomalieDataAccess(_dbContext, _loggerFactory);

                return _LstanomalieDataAccess;
            }
        }

        public ILstc1schemafamDataAccess _Lstc1schemafamDataAccess;
        public ILstc1schemafamDataAccess Lstc1schemafamDataAccess
        {
            get
            {
                if (_Lstc1schemafamDataAccess is null)
                    _Lstc1schemafamDataAccess = new Lstc1schemafamDataAccess(_dbContext, _loggerFactory);

                return _Lstc1schemafamDataAccess;
            }
        }
        public ILstc1schemacatDataAccess _Lstc1schemacatDataAccess;
        public ILstc1schemacatDataAccess Lstc1schemacatDataAccess
        {
            get
            {
                if (_Lstc1schemacatDataAccess is null)
                    _Lstc1schemacatDataAccess = new Lstc1schemacatDataAccess(_dbContext, _loggerFactory);

                return _Lstc1schemacatDataAccess;
            }
        }


        public IHisprojetdepartDataAccess _HisprojetdepartDataAccess;
        public IHisprojetdepartDataAccess HisprojetdepartDataAccess
        {
            get
            {
                if (_HisprojetdepartDataAccess is null)
                    _HisprojetdepartDataAccess = new HisprojetdepartDataAccess(_dbContext, _loggerFactory);

                return _HisprojetdepartDataAccess;
            }
        }

        ILstimagetypeDataAccess IUnitOfWork.LstimagetypeDataAccess
        {
            get
            {
                if (_LstimagetypeDataAccess is null)
                   _LstimagetypeDataAccess = new LstimagetypeDataAccess(_dbContext, _loggerFactory);

                return _LstimagetypeDataAccess;
            }
        }

      

     
       

        public UnitOfWork(API_MySIRHDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _loggerFactory = loggerFactory;

        }

        public IDataAccess<TEntity> DataAccess<TEntity, Tkey>()
            where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            string type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                object repositoryInstance = Tools.CreateInstantOf<DataAccess<TEntity>>(
                    new Type[] { typeof(API_MySIRHDbContext), typeof(ILoggerFactory) }, new object[] { _dbContext, _loggerFactory });

                _repositories.Add(type, repositoryInstance);
            }

            return (IDataAccess<TEntity>)_repositories[type];
        }




        public ILstimagetypeDataAccess LstimagetypeDataAccess
        {
            get
            {
                if (_LstimagetypeDataAccess is null)
                    _LstimagetypeDataAccess = new LstimagetypeDataAccess(_dbContext, _loggerFactory);

                return _LstimagetypeDataAccess;
            }
        }
        public IFluUserwebDataAccess _FluuserwebDataAccess;
        public IFluUserwebDataAccess FluuserwebDataAccess
        {
            get
            {
                if (_FluuserwebDataAccess is null)
                    _FluuserwebDataAccess = new FluUserwebDataAccess(_dbContext, _loggerFactory);

                return _FluuserwebDataAccess;
            }
        }

    public ISupPortqrDataAccess SupportqrDataAccess
        {
            get
            {
                if (_SupportqrDataAccess is null)
                    _SupportqrDataAccess = new SupPortqrDataAccess(_dbContext, _loggerFactory);

                return _SupportqrDataAccess;
            }
        }
        public ILstregimeDataAccess _LstregimeDaxtaAccess;
        public ILstregimeDataAccess LstregimeDaxtaAccess
        { 
            get
            {
                if (_LstregimeDaxtaAccess is null)
                    _LstregimeDaxtaAccess = new LstregimeDataAccess(_dbContext, _loggerFactory);

                return _LstregimeDaxtaAccess;
            }
        }
       public ILstouvragetypeDataAccess LstouvragetypeDataAccess
            {
                get
                {
                    if (_LstouvragetypeDataAccess is null)
                    _LstouvragetypeDataAccess = new LstouvragetypeDataAccess(_dbContext, _loggerFactory);

                    return _LstouvragetypeDataAccess;
                }
            }
        ILstouvragetypecompDataAccess _LstouvragetypecompDataAccess;
        public ILstouvragetypecompDataAccess LstouvragetypecompDataAccess
        {
            get
            {
                if (_LstouvragetypecompDataAccess is null)
                    _LstouvragetypecompDataAccess = new LstouvragetypecompDataAccess(_dbContext, _loggerFactory);

                return _LstouvragetypecompDataAccess;
            }
        }




        //public IDataAccess<TEntity, TKey> DataAccess<TEntity, TKey>()
        //    where TEntity : class
        //{
        //    if (_repositoriesWithKey == null)
        //    {
        //        _repositoriesWithKey = new Hashtable();
        //    }

        //    string type = typeof(TEntity).Name;

        //    if (!_repositoriesWithKey.ContainsKey(type))
        //    {

        //        object repositoryInstance = Tools.CreateInstantOf<DataAccess<TEntity, TKey>>(
        //            new Type[] { typeof(API_MySIRHDbContext), typeof(ILoggerFactory) }, new object[] { _dbContext, _loggerFactory });

        //        _repositoriesWithKey.Add(type, repositoryInstance);
        //    }

        //    return (IDataAccess<TEntity, TKey>)_repositoriesWithKey[type];
        //}











        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, parameters);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public void ResetContextState()
        {
            _dbContext.ChangeTracker.Entries().Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);
        }

        public async Task SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();

      
    }
}
