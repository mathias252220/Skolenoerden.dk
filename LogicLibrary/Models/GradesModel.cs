using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Models
{
	public class GradesModel
	{
		public List<GradeModel> Grades { get; set; } =
		[
			new GradeModel() { Name = "0. klasse", ID = "GradeZero" },
			new GradeModel() { Name = "1. og 2. klasse", ID = "GradeOneTwo" }
		];
    }
}
