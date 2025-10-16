using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Latypova
{
    struct Student
    {
        public string LastName;
        public string FirstName;
        public int YearOfBirth;
        public string Exam;
        public int Score;

        public override string ToString()
        {
            return $"{LastName} {FirstName}, {YearOfBirth}, {Exam}, {Score}";
        }
    }

    class Program
    {
       // Метод для графа
        static List<int> BFSShortestPath(Dictionary<int, List<int>> graph, int start, int goal)
        {
            if (start == goal) return new List<int> { start };
            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            var parent = new Dictionary<int, int>();
            queue.Enqueue(start);
            visited.Add(start);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                if (!graph.TryGetValue(node, out var neighbors)) continue;

                foreach (var nb in neighbors)
                {
                    if (visited.Contains(nb)) continue;
                    visited.Add(nb);
                    parent[nb] = node;

                    if (nb == goal)
                    {
                        var path = new List<int>();
                        int cur = goal;
                        while (true)
                        {
                            path.Add(cur);
                            if (cur == start) break;
                            cur = parent[cur];
                        }
                        path.Reverse();
                        return path;
                    }
                    queue.Enqueue(nb);
                }
            }
            return null;
        }
        static void Main()
        {
            // Задание номер 1
            Console.WriteLine("Задание номер 1");
            string imagesFolder = @"C:\СИ ШАРП\Latypova_and_Tumakov\Latypova\bin\Debug\Картинки\";
            List<string> uniqueImages = new List<string>();
            for (int i = 1; i <= 32; i++)
                uniqueImages.Add($"{imagesFolder}image{i}.jpg");
            List<string> images = new List<string>();
            foreach (var img in uniqueImages)
            {
                images.Add(img);
                images.Add(img);
            }
            Console.WriteLine("Исходный список:");
            for (int i = 0; i < images.Count; i++)
                Console.WriteLine($"{i + 1}: {images[i]}");
            Random generator = new Random();
            for (int i = images.Count - 1; i > 0; i--)
            {
                int j = generator.Next(i + 1);
                var temp = images[i];
                images[i] = images[j];
                images[j] = temp;
            }
            Console.WriteLine("\nПеремешанный список:");
            for (int i = 0; i < images.Count; i++)
                Console.WriteLine($"{i + 1}: {images[i]}");
            // Задание номер 2
            Console.WriteLine("\nЗадание номер 2");
            string fileName = @"C:\СИ ШАРП\Latypova_and_Tumakov\Latypova\bin\Debug\Студенты.txt";
            List<Student> students = new List<Student>();
            if (File.Exists(fileName))
            {
                foreach (var line in File.ReadAllLines(fileName))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        Student s = new Student
                        {
                            LastName = parts[0].Trim(),
                            FirstName = parts[1].Trim(),
                            YearOfBirth = int.Parse(parts[2]),
                            Exam = parts[3].Trim(),
                            Score = int.Parse(parts[4])
                        };
                        students.Add(s);
                    }
                }
            }
            else
            {
                Console.WriteLine("⚠️ Файл не найден, он будет создан при выходе из программы.");
            }
            string choice;
            do
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Новый студент");
                Console.WriteLine("2. Удалить");
                Console.WriteLine("3. Сортировать");
                Console.WriteLine("4. Показать всех");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Student s = new Student();
                        Console.Write("Фамилия: "); s.LastName = Console.ReadLine();
                        Console.Write("Имя: "); s.FirstName = Console.ReadLine();
                        Console.Write("Год рождения: "); s.YearOfBirth = int.Parse(Console.ReadLine());
                        Console.Write("Экзамен: "); s.Exam = Console.ReadLine();
                        Console.Write("Баллы: "); s.Score = int.Parse(Console.ReadLine());
                        students.Add(s);
                        Console.WriteLine("✅ Студент добавлен!");
                        break;

                    case "2":
                        Console.Write("Введите фамилию: ");
                        string last = Console.ReadLine();
                        Console.Write("Введите имя: ");
                        string first = Console.ReadLine();

                        int index = students.FindIndex(x => x.LastName == last && x.FirstName == first);
                        if (index >= 0)
                        {
                            students.RemoveAt(index);
                            Console.WriteLine("❌ Студент удалён!");
                        }
                        else Console.WriteLine("Студент не найден!");
                        break;

                    case "3":
                        students = students.OrderBy(x => x.Score).ToList();
                        Console.WriteLine("✅ Список отсортирован по баллам!");
                        break;

                    case "4":
                        if (students.Count == 0)
                        {
                            Console.WriteLine("⚠️ Список студентов пуст!");
                        }
                        else
                        {
                            Console.WriteLine("\nСписок студентов:");
                            foreach (var st in students)
                                Console.WriteLine(st);
                        }
                        break;

                    case "5":
                        File.WriteAllLines(fileName, students.Select(x =>
                            $"{x.LastName},{x.FirstName},{x.YearOfBirth},{x.Exam},{x.Score}"));
                        Console.WriteLine("💾 Данные сохранены в файл и программа завершена.");
                        break;

                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }

            } while (choice != "5");
            // Задание номер 4
            Console.WriteLine("Задание номер 4");
            var graph = new Dictionary<int, List<int>>
            {
                {1, new List<int> {2, 3}},
                {2, new List<int> {1, 4, 5}},
                {3, new List<int> {1, 6}},
                {4, new List<int> {2}},
                {5, new List<int> {2, 6}},
                {6, new List<int> {3, 5, 7}},
                {7, new List<int> {6}}
            };
            Console.Write("Введите начальную вершину: ");
            int start = int.Parse(Console.ReadLine() ?? "1");
            Console.Write("Введите конечную вершину: ");
            int goal = int.Parse(Console.ReadLine() ?? "7");
            var path = BFSShortestPath(graph, start, goal);
            if (path == null)
                Console.WriteLine($"Пути от {start} до {goal} не существует.");
            else
                Console.WriteLine("Кратчайший путь: " + string.Join(" -> ", path));

            Console.WriteLine("\nПрограмма завершена.");
        }
    }
}




