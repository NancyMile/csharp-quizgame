using System.Net.Mime;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Quiz Game");
var questions = new List<Question>();

SeedQuestionsAndOptions();


void SeedQuestionsAndOptions()
{
    questions.Add(new Question
    {
        Id = 1,
        QuestionText = "What is the biggest country?",
        Options = new List<Option>()
        {
            new Option { Id = 1, Text = "Australia"},
            new Option { Id = 2, Text = "China"},
            new Option { Id = 3, Text = "Russia", IsValid = true},
            new Option { Id = 4, Text = "India"}
        }
    });

    questions.Add(new Question
    {
        Id = 2,
        QuestionText = "Most populated country",
        Options = new List<Option>()
        {
            new Option { Id = 1, Text = "China", IsValid = true},
            new Option { Id = 2, Text = "India" },
            new Option { Id = 3, Text = "Brazil"},
            new Option { Id = 4, Text = "Russia"},
        }
    });

    questions.Add(new Question
    {
        Id = 3,
        QuestionText = "Less corrupt  country",
        Options = new List<Option>()
        {
            new Option { Id = 1, Text = "Japan"},
            new Option { Id = 2, Text = "India"},
            new Option { Id = 3, Text = "Taiwan"},
            new Option { Id = 4, Text = "Denmark", IsValid = true}
        }
    });

    questions.Add(new Question
    {
        Id = 4,
        QuestionText = "Better Quality of life",
        Options = new List<Option>()
        {
            new Option { Id = 1, Text = "Norway"},
            new Option { Id = 2, Text = "Denmark", IsValid = true },
            new Option { Id = 3, Text = "Italy" },
            new Option { Id = 4, Text = "Taiwan"}
        }
    });
}
