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

        // === ������� 4: GetAll � sortStrategy ===
        [HttpGet("all")]
        public IActionResult GetAll(int? sortStrategy)
        {
            var list = new List<string>(Summaries); // �����

            if (sortStrategy == null)
            {
                return Ok(list);
            }

            if (sortStrategy == 1)
            {
                list.Sort(); // �� �����������
                return Ok(list);
            }

            if (sortStrategy == -1)
            {
                list.Sort();
                list.Reverse(); // �� ��������
                return Ok(list);
            }

            return BadRequest("������������ �������� ��������� sortStrategy. ����������: null, 1, -1.");
        }

        // === ������� 2: �������� ������� �� ������� ===
        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {
            // === ������� 1: �������� ���������� ===
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("������ ������� �� ������� ����������� ���������.");
            }

            return Ok(Summaries[index]);
        }

        // === ������� 3: ���������� ������� �� ����� ===
        [HttpGet("find-by-name")]
        public IActionResult GetCountByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("�������� 'name' �� ����� ���� ������.");
            }

            int count = Summaries.Count(s => s.Equals(name, StringComparison.OrdinalIgnoreCase));
            return Ok(count);
        }

        // ��������� ������ (POST, PUT, DELETE) ��������� ��� ���������
        [HttpPost]
        public IActionResult Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("��� �� ����� ���� ������.");

            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("����� ������ ��������!!!");
            }

            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("��� �� ����� ���� ������.");

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("������ ������� �� ������� ����������� ���������.");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }
    }
}