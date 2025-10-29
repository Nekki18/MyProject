using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // === ЗАДАНИЕ 4: GetAll с sortStrategy ===
        [HttpGet("all")]
        public IActionResult GetAll(int? sortStrategy)
        {
            var list = new List<string>(Summaries); // копия

            if (sortStrategy == null)
            {
                return Ok(list);
            }

            if (sortStrategy == 1)
            {
                list.Sort(); // по возрастанию
                return Ok(list);
            }

            if (sortStrategy == -1)
            {
                list.Sort();
                list.Reverse(); // по убыванию
                return Ok(list);
            }

            return BadRequest("Некорректное значение параметра sortStrategy. Допустимые: null, 1, -1.");
        }

        // === ЗАДАНИЕ 2: Получить элемент по индексу ===
        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {
            // === ЗАДАНИЕ 1: Проверка параметров ===
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Индекс выходит за пределы допустимого диапазона.");
            }

            return Ok(Summaries[index]);
        }

        // === ЗАДАНИЕ 3: Количество записей по имени ===
        [HttpGet("find-by-name")]
        public IActionResult GetCountByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Параметр 'name' не может быть пустым.");
            }

            int count = Summaries.Count(s => s.Equals(name, StringComparison.OrdinalIgnoreCase));
            return Ok(count);
        }

        // Остальные методы (POST, PUT, DELETE) оставляем без изменений
        [HttpPost]
        public IActionResult Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Имя не может быть пустым.");

            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!");
            }

            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Имя не может быть пустым.");

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Индекс выходит за пределы допустимого диапазона.");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }
    }
}