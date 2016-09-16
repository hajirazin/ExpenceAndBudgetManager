using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ExpenceAndBudgetManager.Mvc.Models;

namespace ExpenceAndBudgetManager.Mvc.Controllers
{
    [RoutePrefix("api/Expense")]
    public class ExpenseController : ApiController
    {
        [Route("Delete")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int expenceId)
        {
            try
            {
                using (var e = new ApplicationDbContext())
                {
                    var ex = await e.Expenses.FirstOrDefaultAsync(exp => exp.Id == expenceId);
                    if (ex == null)
                        return BadRequest();

                    e.Expenses.Remove(ex);
                    await e.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception exception)
            {
                return Ok("Azure me kik problem aay. " + GetMessage(exception));
            }

        }

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add(int amount, string description)
        {
            try
            {
                using (var e = new ApplicationDbContext())
                {
                    var ex = e.Expenses.Add(new Expense
                    {
                        Amount = amount,
                        Date = DateTime.UtcNow,
                        Description = description,
                        ExpenseGroupId = 18
                    });

                    e.SaveChanges();
                    return Ok(ex);
                }
            }
            catch (Exception exception)
            {
                return Ok("Azure me kik problem aay. " + GetMessage(exception));
            }

        }

        [HttpGet]
        [Route("All")]
        public List<Expense> Get()
        {
            using (var e = new ApplicationDbContext())
            {
                return e.Expenses.ToList().Select(s => new Expense
                {
                    Amount = s.Amount,
                    Date = s.Date,
                    Description = s.Description,
                    Id = s.Id

                }).ToList();
            }
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetForToday()
        {
            return GetByDate(DateTime.UtcNow.Date);
        }

        [HttpGet]
        [Route("{date}")]
        public IHttpActionResult GetByDate(DateTime date)
        {
            try
            {
                using (var e = new ApplicationDbContext())
                {
                    var dateMonth = date.Month;
                    decimal monthCount = 0;
                    var monthQuery = e.Expenses.Where(ex => ex.Date.Month == dateMonth).Select(s => s.Amount);
                    if (monthQuery.Any())
                        monthCount = monthQuery.Sum();
                    var list =
                        e.Expenses.Where(ex => DbFunctions.TruncateTime(ex.Date) == date)
                            .ToList()
                            .Select(s => new Expense
                            {
                                Amount = s.Amount,
                                Date = s.Date,
                                Description = s.Description,
                                Id = s.Id
                            }).ToList();
                    return Ok(new
                    {
                        Data = list,
                        TodayTotal = list.Count == 0 ? 0 : list.Select(s => s.Amount).Sum(),
                        ThisMonthTotal = monthCount
                    });
                }
            }
            catch (Exception exception)
            {
                return Ok("Azure me kik problem aay. " + GetMessage(exception));
            }
        }

        private static string GetMessage(Exception exception)
        {
            var s = new List<string>();
            while (exception != null)
            {
                s.Add(exception.Message);
                exception = exception.InnerException;
            }

            return string.Join(" || ", s);
        }
    }
}