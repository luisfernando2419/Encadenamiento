namespace Encadenamientoo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ForwardChaining
    {
        // Representa una regla con una condición (premisa) y una acción (conclusión)
        class Rule
        {
            public List<string> Conditions { get; set; }
            public string Conclusion { get; set; }

            public Rule(List<string> conditions, string conclusion)
            {
                Conditions = conditions;
                Conclusion = conclusion;
            }
        }

        static void Main()
        {
            // Hechos iniciales
            HashSet<string> facts = new HashSet<string>
        {
            "El cielo está nublado",
            "El coche está afuera"
        };

            // Reglas
            List<Rule> rules = new List<Rule>
        {
            new Rule(new List<string> { "El cielo está nublado" }, "Va a llover"),
            new Rule(new List<string> { "Va a llover" }, "Llevar paraguas"),
            new Rule(new List<string> { "Va a llover", "El coche está afuera" }, "Cubrir el coche"),
            new Rule(new List<string> { "Está lloviendo" }, "El suelo está mojado"),
            new Rule(new List<string> { "El suelo está mojado" }, "Usar botas de lluvia")
        };

            // Aplicar encadenamiento hacia adelante
            bool newFactAdded;
            do
            {
                newFactAdded = false;
                foreach (var rule in rules)
                {
                    // Si todos los hechos de las condiciones están presentes, aplica la regla
                    if (rule.Conditions.All(condition => facts.Contains(condition)))
                    {
                        if (!facts.Contains(rule.Conclusion))
                        {
                            Console.WriteLine($"Aplicando regla: Si {string.Join(" y ", rule.Conditions)}, entonces {rule.Conclusion}");
                            facts.Add(rule.Conclusion);
                            newFactAdded = true;
                        }
                    }
                }
            } while (newFactAdded);

            // Resultados finales
            Console.WriteLine("\nConclusiones finales:");
            foreach (var fact in facts)
            {
                Console.WriteLine(fact);
            }
        }
    }

}
