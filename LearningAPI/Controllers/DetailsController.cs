using AutoMapper;
using LearningAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data;

namespace LearningAPI.Controllers
{
    [ApiController]
    
    [Route("[controller]")]

    [Authorize]

    public class DetailsController : Controller
    {
        private readonly IDetails _details;
        private IMapper _mapper { get; set; }
        public DetailsController(IDetails _details, IMapper _mapper)
        {
            this._details = _details;
            this._mapper = _mapper;

        }
        #region("Asynchronous")
        [HttpGet]
        [Route("GetData")]
        [Authorize(Roles = "user")]

        public async Task<IEnumerable<DTO.Datum>> GetAllDetails()
        {
            var data = await _details.GetAllData();

            var dataDto = _mapper.Map<List<DTO.Datum>>(data);
           
            return dataDto;
        }

        [HttpGet]
        [Route("GetTableData")]
        [Authorize(Roles = "user")]

        public async Task<IEnumerable<DTO.TableDataDTO>> GetTableData()
        {
            var data = await _details.GetTableNames();

            var dataDto = _mapper.Map<List<DTO.TableDataDTO>>(data);

            return dataDto;
        }

        [HttpGet]
        [Route("GetSPData")]
        [Authorize(Roles = "user")]

        public async Task<IEnumerable<DTO.SPDataDTO>> GetSPData()
        {
            var data = await _details.GetSPNames();

            var dataDto = _mapper.Map<List<DTO.SPDataDTO>>(data);

            return dataDto;
        }

        [HttpGet]
        [Route("GetDataById/{id:int}")]
        [Authorize(Roles = "user")]

        public async Task<IEnumerable<DTO.Datum>> GetDetailsById([FromRoute]int id)
        {
            var data = await _details.GetDataById(id);

            var dataDto = _mapper.Map<List<DTO.Datum>>(data);

            return dataDto;
        }

        [HttpPost]
        [Route("PostData")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> PostDetails(DTO.AddDatum datum)
        {
            var detail = new Datum()
            {
                Name = datum.Name,
                ExpiryDate = datum.ExpiryDate,
                Gender = datum.Gender,
            };

            detail = await _details.PostData(detail);

            var dataDto = _mapper.Map<DTO.AddDatum>(detail);

            return Ok(dataDto);

        }

        [HttpPost]
        [Route("PostSPData")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> PostSPData(SaveSPData savedata)
        {
            string detail = await _details.SaveSpData(savedata.sqlQuery, savedata.spName);
            return Ok(detail);
        }

        [HttpDelete]
        [Route("DeleteData")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteDetail(int Id)
        {
      
            var delete = await _details.DeleteData(Id);

            return Ok(delete);

        }

        [HttpPut]
        [Route("UpdateData/{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateDetail([FromRoute]int id, [FromBody]DTO.UpdateDatum datum)
        {
            var details = new Datum() 
            {
                Id = id,
                Name = datum.Name,
                ExpiryDate = datum.ExpiryDate,
                Gender = datum.Gender,
            };

            var data = await _details.UpdateData(id, details);

            if(data != null) {
                var detailsDto = new DTO.UpdateDatum()
                {
                    Name = data.Name,
                    ExpiryDate = data.ExpiryDate,
                    Gender = data.Gender,
                };
                return Ok(detailsDto);
            }
            else
            {
                return NotFound();
            }

            

        }
        #endregion

        //#region("Synchronous")

        //[HttpGet]
        //[Route("GetDetailsSync")]
        //public List<DTO.Datum> GetDetailsSync()
        //{
        //    var data = _details.GetData();
        //    var dataDto = _mapper.Map<List<DTO.Datum>>(data);
        //    return dataDto;
        //}

        //[HttpPost]
        //[Route("PostDetailsSync")]
        //public int PostDetailsSync(DTO.AddDatum datum)
        //{
        //    var detail = new Datum()
        //    {
        //        Name = datum.Name,
        //        ExpiryDate = datum.ExpiryDate,
        //        Gender = datum.Gender,
        //    };

        //    var data = _details.PostDataSync(detail);
        //    return data;
        //}

        //[HttpDelete]
        //[Route("DeleteDetailsSync/{Id:int}")]
        //public int DeleteDetailsSync([FromRoute]int Id)
        //{
        //    var data = _details.DeleteDataSync(Id);
            
        //    return 1;
        //}

        //[HttpPut]
        //[Route("UpdateDetailsSync/{id:int}")]
        //public string UpdateDetailsSync(int id, DTO.UpdateDatum datum)
        //{
        //    var detail = new Datum()
        //    {
        //        Name = datum.Name,
        //        ExpiryDate = datum.ExpiryDate,
        //        Gender = datum.Gender,
        //    };

        //    var data = _details.UpdateDataSync(id, detail);

        //    return data;
        //}
        //#endregion

    }
}
