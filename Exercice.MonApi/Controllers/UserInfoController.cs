using AutoMapper;
using Exercice.Dto;
using Exercice.Persistance;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercice.MonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private MonApiContext _context;
        private IMapper _mapper;
        public UserInfoController(MonApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<ApiController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserInfoDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(_context.UserInfosEntity.Select(user => _mapper.Map<UserInfoDto>(user)));
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserInfoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                var UserEntityById = _context.UserInfosEntity.Single(u => u.UserId == id);
                var userDtoById = _mapper.Map<UserInfoDto>(UserEntityById);
                return Ok(UserEntityById);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        // POST api/<ApiController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserInfoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] UserInfoDto newUserInfo)
        {
            try
            {
                var userInfoEntity = _mapper.Map<UserInfoEntity>(newUserInfo);
                _context.UserInfosEntity.Add(userInfoEntity);
                _context.SaveChanges();
                return Ok(newUserInfo);    
                // autre facon :
               // return base.Created(Request.Query.ToString(), userInfoEntity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserInfoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, UserInfoDto updateDto)
        {
            try
            {
                var userInfoEntity = _mapper.Map<UserInfoEntity>(updateDto);

                var updateUser = _context.UserInfosEntity.Single(u => u.UserId == id);
                updateUser.UserFirstName = userInfoEntity.UserFirstName;
                updateUser.UserLastName = userInfoEntity.UserLastName;
                updateUser.EmailAddress = userInfoEntity.EmailAddress;
                updateUser.CompanyName = userInfoEntity.CompanyName;
                updateUser.Phone = userInfoEntity.Phone;
                //var userInfoEntity = _mapper.Map<UserInfoEntity>(updateDto);
                //userInfoEntity.UserFirstName = 
                _context.UserInfosEntity.Update(updateUser);
                _context.SaveChanges();
                return Ok(updateDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserInfoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                var deleteUser = _context.UserInfosEntity.Single(u => u.UserId == id);
                _context.UserInfosEntity.Remove(deleteUser);
                _context.SaveChanges();
                return Ok(deleteUser);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }



    }
}
