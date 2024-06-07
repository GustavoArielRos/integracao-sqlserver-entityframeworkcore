using Microsoft.AspNetCore.Mvc;
using Users.Domain.Entidades;
using Users.Infraestrutura;

namespace Users.API.Controllers
{

    [ApiController] //dizendo para o controlador que isso é uma APIcontroler
    [Route("[controller]")] //dizendo que a rota é o próprio nome do controler
    public class UserController : ControllerBase
    {
        //importando o contexto(onde tem os dados do banco )
        private UserDbContext _db;

        //construtor para a variável acima ter os dados
        
        public UserController(UserDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [HttpGet]//Rota que pega todas as informações do banco de dados
        public IActionResult Get()
        {
            var users = _db.Users.ToList();
            return Ok(users);//o "ok" é o código 200
        }

        [HttpPost]//Rota que adiciona um usuário ao banco de dados
        public IActionResult Add(User user)
        {
            var users = _db.Users.Add(user);//adicionando no banco de dados
            _db.SaveChanges();//salvando a modificação
            return Ok(users.Entity);//o "ok" é o código 200, o ".Entity" é pq retorna a entidade
        }
    }
}
