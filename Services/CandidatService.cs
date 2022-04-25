

namespace API_MySIRH.Services
{
    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using API_MySIRH.Interfaces;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using System.Drawing;
    using System.Net.Http.Headers;

    public class CandidatService: ICandidatService
    {
        private readonly ICandidatRepository _CandidatRepository;
        private readonly IMapper _mapper;

        public CandidatService(ICandidatRepository CandidatRepository, IMapper mapper)
        {
            this._CandidatRepository = CandidatRepository;
            this._mapper = mapper;
        }

        public async Task<CandidatDTO> AddCandidat(CandidatDTO Candidat)
        {
            var returnedCandidat = await this._CandidatRepository.AddCandidat(this._mapper.Map<Candidat>(Candidat));
            return this._mapper.Map<CandidatDTO>(returnedCandidat);
        }

        public async Task DeleteCandidat(int id)
        {
            await this._CandidatRepository.DeleteCandidat(id);
        }

       

        public async Task<CandidatDTO> GetCandidat(int id)
        {
            return this._mapper.Map<CandidatDTO>(await this._CandidatRepository.GetCandidat(id));
        }

        public async Task<IEnumerable<CandidatDTO>> GetCandidats()
        {
            //var query = this._CandidatRepository.GetCandidats().ProjectTo<CandidatDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Candidat>, PagedList<CandidatDTO>>(collabs);
            //return await PagedList<CandidatDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _CandidatRepository.GetCandidats();
            return _mapper.Map<IEnumerable<Candidat>, IEnumerable<CandidatDTO>>(result);
        }
        public async Task UpdateCandidat(int id, CandidatDTO Candidat)
        {

            var oldCandidat=await   this._CandidatRepository.GetCandidat(id);
            Candidat.CVUrl = oldCandidat.CVUrl;
            Candidat.ImageUrl = oldCandidat.ImageUrl;

          await this._CandidatRepository.UpdateCandidat(id, this._mapper.Map<Candidat>(Candidat));
        }
        public async Task<IEnumerable<CandidatDTO>> ImportExcel(IFormFile Excel)
        {
            if (Excel?.Length > 0)
            {
                var stream = Excel.OpenReadStream();

                try
                {
                    using (var package = new ExcelPackage(stream))
                    {

                        var worksheet = package.Workbook.Worksheets.First();//package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;

                        for (var row = 5; row <= rowCount; row++)
                        {
                            try
                            {
                               
                                var _Nom = worksheet.Cells[row, 1].Value?.ToString();
                                var _Prenom = worksheet.Cells[row, 2].Value?.ToString();
                                var _DateNaissance = worksheet.Cells[row, 3].Value?.ToString();
                                var _Civilite = worksheet.Cells[row, 4].Value?.ToString();
                                var _Email = worksheet.Cells[row, 5].Value?.ToString();
                                var _Telephone = worksheet.Cells[row, 6].Value?.ToString();
                                var _DatePremiereExperience = worksheet.Cells[row, 7].Value?.ToString();
                                var _SalaireActuel = worksheet.Cells[row, 8].Value?.ToString();
                                var _PropositionSalariale = worksheet.Cells[row, 9].Value?.ToString();
                                var _ResidenceActuelle = worksheet.Cells[row, 10].Value?.ToString();
                                var _EmploiEncore = worksheet.Cells[row, 11].Value?.ToString();
                                var _Poste = worksheet.Cells[row, 12].Value?.ToString();
                                var _Niveau = worksheet.Cells[row, 13].Value?.ToString();
                                var _Commentaire = worksheet.Cells[row, 14].Value?.ToString();

                                var Candidat = new Candidat()
                                {
                                    Civilite = _Civilite,
                                    Commentaire = _Commentaire,
                                    DateNaissance = DateTime.Parse(_DateNaissance),
                                    Email = _Email,
                                    Telephone = _Telephone,
                                    Id = 0,
                                    DatePremiereExperience = DateTime.Parse(_DatePremiereExperience),
                                    Prenom = _Prenom,
                                    Nom = _Nom,
                                    PropositionSalariale = decimal.Parse(_PropositionSalariale),
                                    ResidenceActuelle = _ResidenceActuelle,
                                    EmploiEncore = _EmploiEncore,
                                    SalaireActuel = decimal.Parse(_SalaireActuel),
                                    PosteId=int.Parse(_Poste),
                                    PosteNiveauId=int.Parse(_Niveau),

                                };
                                _CandidatRepository.AddCandidat(Candidat);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                            }

                            }

                    }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            var Cadidats= await _CandidatRepository.GetCandidats();

            return  _mapper.Map<IEnumerable<Candidat>, IEnumerable<CandidatDTO>>(Cadidats);
        }
        public async Task<FileStreamResult> ExportExcel()
        {
            var Cadidats =await  _CandidatRepository.GetCandidats();
            var stream = new MemoryStream();
            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Cadidats");
                var namedStyle = xlPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
                namedStyle.Style.Font.UnderLine = true;
                namedStyle.Style.Font.Color.SetColor(Color.Blue);
                const int startRow = 3;
                var row = startRow;


                worksheet.Cells["A4"].Value = "Nom";
                worksheet.Cells["B4"].Value = "Prenom";
                worksheet.Cells["C4"].Value = "Date de Naissance";
                worksheet.Cells["D4"].Value = "Civilite";
                worksheet.Cells["E4"].Value = "Email";
                worksheet.Cells["F4"].Value = "Telephone";
                worksheet.Cells["G4"].Value = "Date Premiere Experience";
                worksheet.Cells["H4"].Value = "Salaire Actuel";
                worksheet.Cells["I4"].Value = "Proposition Salariale";
                worksheet.Cells["J4"].Value = "Residence Actuellel";
                worksheet.Cells["K4"].Value = "Emploi Encore";
                worksheet.Cells["L4"].Value = "Poste";
                worksheet.Cells["M4"].Value = "Niveau";
                worksheet.Cells["N4"].Value = "Commentaire";
                worksheet.Cells["A4:N4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A4:N4"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                worksheet.Cells["A4:N4"].Style.Font.Bold = true;


                row = 5;
                foreach (var user in Cadidats)
                {   
                    worksheet.Cells[row, 1].Value = user?.Nom;
                    worksheet.Cells[row, 2].Value = user?.Prenom;
                    worksheet.Cells[row, 3].Value = user?.DateNaissance?.ToString("MMMM dd, yyyy");
                    //  if (user?.Civilite?.ToString() == "H") { worksheet.Cells[row, 4].Value = "Mr."; } else worksheet.Cells[row, 4].Value = "Mms";
                    worksheet.Cells[row, 4].Value = user?.Civilite;
                    worksheet.Cells[row, 5].Value = user?.Email;
                    worksheet.Cells[row, 6].Value = user?.Telephone;
                    worksheet.Cells[row, 7].Value = user?.DatePremiereExperience?.ToString("MMMM dd, yyyy");;
                    worksheet.Cells[row, 8].Value = user?.SalaireActuel;
                    worksheet.Cells[row, 9].Value = user?.PropositionSalariale;
                    worksheet.Cells[row, 10].Value = user?.ResidenceActuelle;
                    worksheet.Cells[row, 11].Value = user?.EmploiEncore;
                    worksheet.Cells[row, 12].Value = user?.PosteId ;
                    worksheet.Cells[row, 13].Value = user?.PosteNiveauId;
                    worksheet.Cells[row, 14].Value = user?.Commentaire;

                    row++;
                }

                // set some core property values
                xlPackage.Workbook.Properties.Title = "Cadidats List";
                xlPackage.Workbook.Properties.Author = "MYSIRH";
                xlPackage.Workbook.Properties.Subject = "Cadidats List";
                // save the new spreadsheet
                xlPackage.Save();
                // Response.Clear();

            }

              stream.Position = 0;
            return new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "Candidats.xlsx"
            };

        }
        public async Task<CandidatDTO> Upload(IFormFile file,  int id, bool cv)
        {
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = id + Guid.NewGuid().ToString();
                    var fullPath = Path.Combine(folderName+"\\"+ fileName + extension);
                    var dbPath = Path.Combine(fileName+ extension);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    Candidat candidat = await _CandidatRepository.GetCandidat(id);
                    // cv ? candidat.CVUrl = dbPath:candidat.ImageUrl = dbPath;
                    _ = cv? candidat.CVUrl = dbPath : candidat.ImageUrl = dbPath;
                    var save = _CandidatRepository.UpdateCandidat(id, candidat);


                    return _mapper.Map<Candidat,CandidatDTO>(candidat);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {

                throw ex;
                
            }
        }

        public async Task<FileStreamResult> GetFile(string UniqueName)
        {
            try
            {
                var extension = "." + UniqueName.Split('.')[UniqueName.Split('.').Length - 1];
                var path = Directory.GetCurrentDirectory() + "\\Resources\\Images\\" + UniqueName;
                var image= System.IO.File.OpenRead(path);
               // return File(image, "image/jpeg");
                //var stream = new FileStream(path, FileMode.Open);
               // stream.Position = 0;
                return new FileStreamResult(image, "image/"+ extension)
                {
                    FileDownloadName = UniqueName,
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

