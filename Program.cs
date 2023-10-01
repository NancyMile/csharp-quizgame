
// See https://aka.ms/new-console-template for more information

string playerName;
var questions = new List<Question>();
var answers = new List<Answer>();
var scores = new Dictionary<string,int>();

SeedQuestionsAndOptions();
StartGame();

void StartGame()
{
    Console.WriteLine("Quiz Game");
    Console.WriteLine("What is your Name?");
    playerName = Console.ReadLine();
    Console.WriteLine($"Welcome {playerName}");

   try
   {
        foreach (var question in questions)
        {
            Console.WriteLine(question.QuestionText);
            Console.WriteLine("Please type the number corresponding to your response");
            foreach (var option in question.Options)
            {
                Console.WriteLine($"{option.Id} {option.Text}");
            }
           var selectedOption = GetSelectedAnswer();
           AddAnswerToList(selectedOption,question);
        }
        int score = GetScore();
        Console.WriteLine($"Nice try {playerName} score: {score}");
        UpdateScore(playerName,score);
        ShowScores();
        //play again or close game
        answers = new List<Answer>();
        Console.WriteLine("Do you want to play again?");
        Console.WriteLine("enter yes or not");
        var playAgain = Console.ReadLine();
        if(playAgain?.ToLower().Trim() == "yes")
            StartGame();
   }
   catch (Exception e)
   {
        Console.WriteLine($"Error: {e.Message}");
   }
}

string GetSelectedAnswer()
{
    var selectedOption = Console.ReadLine();

    if(selectedOption != null && (selectedOption == "1") || (selectedOption == "2") || (selectedOption == "3") || (selectedOption == "4"))
    {
        return selectedOption;
    }
    else
    {
        Console.WriteLine("The option is not valid, please try again.");
        selectedOption = GetSelectedAnswer();
    }
    return selectedOption;
}

void AddAnswerToList(string selectedOption, Question question)
{
    answers.Add( new Answer
    { QuestionId = question.Id,
      SelectedOption = GetSelectedOption(selectedOption, question)
    });
}

Option GetSelectedOption(string selectedOption, Question question)
{
    var playerSelectedOption = new Option();

    foreach (var option in question.Options)
    {
        if(int.Parse(selectedOption) == option.Id)
        {
            playerSelectedOption = option;
        }
    }

    return playerSelectedOption;
}

int GetScore()
{
    int score = 0;
    foreach (var item in answers)
    {
        if(item.SelectedOption.IsValid)
            score++;
    }
    return score;
}

void UpdateScore(string playerName, int score)
{
    bool updated = false;
    foreach (var item in scores)
    {
        if(item.Key == playerName)
        {
            scores[item.Key] = score;
            updated = true;
        }
    }

    if(!updated)
        {
            scores.Add(playerName,score);
        }
}

void ShowScores(){
    Console.WriteLine("Scores");
    foreach (var item in scores)
    {
        Console.WriteLine($"{item.Key} : {item.Value}");
    }
}

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


    Console.WriteLine(questions);
}
