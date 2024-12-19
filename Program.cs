using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace DressUp {
    public class Program {

        static void Main(string[] args) {
            ShowMainMenu();
        }

        public static void DisplayCharactersWithSearch()
        {
            string connectionString = "server=localhost;user=root;database=dressup;password=";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine("Search Characters:");
                Console.WriteLine("1. Search by Name");
                Console.WriteLine("2. Search by ID");
                Console.WriteLine("3. Show All Characters");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "4")
                    break;

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Available Character Names:\n");

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            MySqlCommand nameCommand = new MySqlCommand("SELECT name FROM characters", connection);

                            using (MySqlDataReader reader = nameCommand.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                        Console.WriteLine($"- {reader["name"]}");
                                }
                                else
                                {
                                    Console.WriteLine("No characters found.");
                                    Console.ReadKey();
                                    continue;
                                }
                            }
                        }

                        Console.Write("\nEnter the name of the character you want to view: ");
                        string selectedName = Console.ReadLine();

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "SELECT * FROM characters WHERE name = @name";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@name", selectedName);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\nDetails for '{selectedName}':\n");
                                    while (reader.Read())
                                        DisplayCharacterDetails(reader);
                                }
                                else
                                {
                                    Console.WriteLine($"\nCharacter '{selectedName}' not found.");
                                }
                            }
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Available Character IDs and Names:\n");

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            MySqlCommand idCommand = new MySqlCommand("SELECT id, name FROM characters", connection);

                            using (MySqlDataReader reader = idCommand.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                        Console.WriteLine($"ID: {reader["id"]} - Name: {reader["name"]}");
                                }
                                else
                                {
                                    Console.WriteLine("No characters found.");
                                    Console.ReadKey();
                                    continue;
                                }
                            }
                        }

                        Console.Write("\nEnter the ID of the character you want to view: ");
                        string selectedId = Console.ReadLine();

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "SELECT * FROM characters WHERE id = @id";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@id", int.Parse(selectedId));

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\nDetails for Character ID '{selectedId}':\n");
                                    while (reader.Read())
                                        DisplayCharacterDetails(reader);
                                }
                                else
                                {
                                    Console.WriteLine($"\nCharacter with ID '{selectedId}' not found.");
                                }
                            }
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Displaying all characters:\n");

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            MySqlCommand command = new MySqlCommand("SELECT * FROM characters", connection);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        Console.WriteLine(new string('-', 50));
                                        DisplayCharacterDetails(reader);
                                        Console.WriteLine(new string('-', 50));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No characters found.");
                                }
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Returning to menu.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

            Console.WriteLine("\nReturning to the main menu...");
            Console.ReadKey();
        }

        private static void DisplayCharacterDetails(MySqlDataReader reader)
        {
            Console.WriteLine($"ID: {reader["id"],-4}");
            Console.WriteLine($"Name: {reader["name"],-15}");
            Console.WriteLine($"Age: {reader["age"],-4}");
            Console.WriteLine($"Role: {reader["role"],-10}");
            Console.WriteLine($"Body Type: {reader["bodytype"],-10}");
            Console.WriteLine($"Skin Tone: {reader["skintone"],-10}");
            Console.WriteLine($"Eye Color: {reader["eyecolor"],-10}");
            Console.WriteLine($"Markings: {reader["markings"],-10}");
            Console.WriteLine($"Expression: {reader["expression"],-10}");
            Console.WriteLine($"Hairstyle: {reader["hairstyle"],-10}");
            Console.WriteLine($"Hair Color: {reader["haircolor"],-10}");
            Console.WriteLine($"Background: {reader["background"],-10}");
            Console.WriteLine($"Lip Color: {reader["lipcolor"],-10}");
            Console.WriteLine($"Eyeshadow: {reader["eyeshadow"],-10}");
            Console.WriteLine($"Eyeliner: {reader["eyeliner"],-10}");
            Console.WriteLine($"Eyebrow: {reader["eyebrow"],-10}");
            Console.WriteLine($"Blush: {reader["blush"],-10}");
            Console.WriteLine($"Dress: {reader["dress"],-10}");
            Console.WriteLine($"Top: {reader["top"],-10}");
            Console.WriteLine($"Bottom: {reader["bottom"],-10}");
            Console.WriteLine($"Footwear: {reader["footwear"],-10}");
            Console.WriteLine($"Weapon: {reader["weapon"],-10}");
            Console.WriteLine($"Jewelry: {reader["jewelry"],-10}");
            Console.WriteLine($"Aura: {reader["aura"],-10}");
            Console.WriteLine($"Protection Ritual Points: {reader["protection"]}");
            Console.WriteLine($"Healing Ritual Points: {reader["healing"]}");
            Console.WriteLine($"Divination Ritual Points: {reader["divination"]}");
            Console.WriteLine($"Curse Ritual Points: {reader["curse"]}");
            Console.WriteLine($"Manifestation Ritual Points: {reader["manifestation"]}");
            Console.WriteLine($"Affinity: {reader["affinity"],-10}");
            Console.WriteLine($"Spell: {reader["spell"],-10}");
            Console.WriteLine($"Companion: {reader["companion"],-10}");
        }

        public static void DeleteCharacter()
        {
            string connectionString = "server=localhost;user=root;database=dressup;password=";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine("Delete Characters:");
                Console.WriteLine("1. Delete by Name");
                Console.WriteLine("2. Delete by ID");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "3")
                    break;

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Available Character Names:\n");

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            MySqlCommand command = new MySqlCommand("SELECT name FROM characters", connection);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                        Console.WriteLine($"- {reader["name"]}");
                                }
                                else
                                {
                                    Console.WriteLine("No characters found.");
                                    Console.ReadKey();
                                    continue;
                                }
                            }
                        }

                        Console.Write("\nEnter the name of the character to delete: ");
                        string nameToDelete = Console.ReadLine();

                        ConfirmAndDeleteCharacter(connectionString, "name", nameToDelete);
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Available Character IDs and Names:\n");

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            MySqlCommand command = new MySqlCommand("SELECT id, name FROM characters", connection);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                        Console.WriteLine($"ID: {reader["id"]} - Name: {reader["name"]}");
                                }
                                else
                                {
                                    Console.WriteLine("No characters found.");
                                    Console.ReadKey();
                                    continue;
                                }
                            }
                        }

                        Console.Write("\nEnter the ID of the character to delete: ");
                        string idToDelete = Console.ReadLine();

                        ConfirmAndDeleteCharacter(connectionString, "id", idToDelete);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Returning to menu.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ConfirmAndDeleteCharacter(string connectionString, string column, string value)
        {
            Console.WriteLine("\nAre you sure you want to delete this character?");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");
            Console.Write("Enter your choice: ");
            string confirmation = Console.ReadLine();

            if (confirmation == "1")
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"DELETE FROM characters WHERE {column} = @value";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    if (column == "id")
                        command.Parameters.AddWithValue("@value", int.Parse(value));
                    else
                        command.Parameters.AddWithValue("@value", value);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("\nCharacter deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("\nCharacter not found. No records deleted.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nDeletion canceled.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void ShowMainMenu() {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("\r\n███╗   ███╗██╗   ██╗███████╗████████╗██╗ ██████╗    ██╗    ██╗ █████╗ ██████╗ ██████╗ ██████╗  ██████╗ ██████╗ ███████╗\r\n████╗ ████║╚██╗ ██╔╝██╔════╝╚══██╔══╝██║██╔════╝    ██║    ██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██╔════╝\r\n██╔████╔██║ ╚████╔╝ ███████╗   ██║   ██║██║         ██║ █╗ ██║███████║██████╔╝██║  ██║██████╔╝██║   ██║██████╔╝█████╗  \r\n██║╚██╔╝██║  ╚██╔╝  ╚════██║   ██║   ██║██║         ██║███╗██║██╔══██║██╔══██╗██║  ██║██╔══██╗██║   ██║██╔══██╗██╔══╝  \r\n██║ ╚═╝ ██║   ██║   ███████║   ██║   ██║╚██████╗    ╚███╔███╔╝██║  ██║██║  ██║██████╔╝██║  ██║╚██████╔╝██████╔╝███████╗\r\n╚═╝     ╚═╝   ╚═╝   ╚══════╝   ╚═╝   ╚═╝ ╚═════╝     ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝ ╚═════╝ ╚═════╝ ╚══════╝\r\n                                                                                                                       \r\n");
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Display Characters");
                Console.WriteLine("3. Delete Character");
                Console.WriteLine("4. Campaign mode");
                Console.WriteLine("5. Credits");
                Console.WriteLine("6. Exit");
                Console.Write("Please choose an option (1-6): ");
                string choice = Console.ReadLine();

                switch (choice) {
                    case "1":
                        try {
                            Character character = Character.CreateCharacter();
                            character.DisplayCharacterInfo();
                        }
                        catch (Exception ex) {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                        break;
                    case "2":
                        DisplayCharactersWithSearch();
                        break;
                    case "3":
                        DeleteCharacter();
                        break;
                    case "4":
                        OpenCampaign();
                        break;
                    case "5":
                        OpenCredits();
                        break;
                    case "6":
                        ExitApp();
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void OpenCampaign()
        {
            Console.Clear();
            Console.WriteLine("\r\n ██████╗ █████╗ ███╗   ███╗██████╗  █████╗ ██╗ ██████╗ ███╗   ██╗\r\n██╔════╝██╔══██╗████╗ ████║██╔══██╗██╔══██╗██║██╔════╝ ████╗  ██║\r\n██║     ███████║██╔████╔██║██████╔╝███████║██║██║  ███╗██╔██╗ ██║\r\n██║     ██╔══██║██║╚██╔╝██║██╔═══╝ ██╔══██║██║██║   ██║██║╚██╗██║\r\n╚██████╗██║  ██║██║ ╚═╝ ██║██║     ██║  ██║██║╚██████╔╝██║ ╚████║\r\n ╚═════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝     ╚═╝  ╚═╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝\r\n                                                                 \r\n");
            Console.WriteLine("In a secluded realm hidden from the mundane world, wizards and witches lived in unity, preserving the balance of magic. Alaric, a young prodigy with an affinity for elemental spells, and Seraphine, a reclusive witch skilled in forbidden enchantments, are thrust into action when a malevolent force begins stealing magical energy from their community. The elders uncover a legend about the Void Talisman, an artifact believed to absorb and destroy magic, and suspect it has been unearthed by an unknown enemy. Alaric and Seraphine are tasked with finding the talisman before their world loses magic forever. Guided by cryptic visions, they embark on a perilous journey to the Shattered Peaks, where the artifact is rumored to lie.");
            Console.WriteLine("");
            Console.WriteLine("Their journey is fraught with dangers, from magical traps to spectral guardians that test their strength and resolve. As they navigate ancient ruins, Alaric begins to suspect Seraphine knows more about the Void Talisman than she admits. They uncover a chilling truth: Seraphine's family once wielded the talisman to dominate the magical world before being overthrown and exiled. When they finally reach the artifact, Seraphine reveals that she secretly seeks to destroy it to atone for her lineage's sins. However, Alaric discovers an even darker secret — the Void Talisman isn't absorbing magic on its own but is being activated by Seraphine herself, as her magical essence is tied to the talisman.");
            Console.WriteLine("");
            Console.WriteLine("In the climactic confrontation, Alaric faces an impossible choice: destroy the talisman and risk Seraphine's life or let her continue using it to end the threat permanently. Seraphine begs him to destroy it, but Alaric hesitates, believing there must be another way. Suddenly, Seraphine reveals her ultimate betrayal — she plans to harness the talisman's power for herself, claiming it's the only way to bring lasting peace to their fractured world. In a fierce battle, Alaric uses his elemental mastery to shatter the talisman, severing its connection to Seraphine and rendering her powerless. Seraphine vanishes in the aftermath, vowing to return and reclaim her destiny, leaving Alaric to grapple with the weight of his actions and the haunting knowledge that the true battle has only just begun.");
            Console.ReadKey();
        }

        static void OpenCredits() {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.WriteLine("\r\n ██████╗██████╗ ███████╗██████╗ ██╗████████╗███████╗\r\n██╔════╝██╔══██╗██╔════╝██╔══██╗██║╚══██╔══╝██╔════╝\r\n██║     ██████╔╝█████╗  ██║  ██║██║   ██║   ███████╗\r\n██║     ██╔══██╗██╔══╝  ██║  ██║██║   ██║   ╚════██║\r\n╚██████╗██║  ██║███████╗██████╔╝██║   ██║   ███████║\r\n ╚═════╝╚═╝  ╚═╝╚══════╝╚═════╝ ╚═╝   ╚═╝   ╚══════╝\r\n                                                    \r\n");
            Console.WriteLine("Condrillon, Cairelle Lyndsay (Laptop)");
            Console.WriteLine("Luntao, Denise Marielle (Kalan, Kaldero)");
            Console.WriteLine("Martinez, Nicole (Pancit Canton)");
            Console.ReadKey();
        }

        static void ExitApp() {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.WriteLine("\r\n████████╗██╗  ██╗ █████╗ ███╗   ██╗██╗  ██╗    ██╗   ██╗ ██████╗ ██╗   ██╗\r\n╚══██╔══╝██║  ██║██╔══██╗████╗  ██║██║ ██╔╝    ╚██╗ ██╔╝██╔═══██╗██║   ██║\r\n   ██║   ███████║███████║██╔██╗ ██║█████╔╝      ╚████╔╝ ██║   ██║██║   ██║\r\n   ██║   ██╔══██║██╔══██║██║╚██╗██║██╔═██╗       ╚██╔╝  ██║   ██║██║   ██║\r\n   ██║   ██║  ██║██║  ██║██║ ╚████║██║  ██╗       ██║   ╚██████╔╝╚██████╔╝\r\n   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝       ╚═╝    ╚═════╝  ╚═════╝ \r\n                                                                          \r\n");
            Console.WriteLine("\r\n███████╗ ██████╗ ██████╗ \r\n██╔════╝██╔═══██╗██╔══██╗\r\n█████╗  ██║   ██║██████╔╝\r\n██╔══╝  ██║   ██║██╔══██╗\r\n██║     ╚██████╔╝██║  ██║\r\n╚═╝      ╚═════╝ ╚═╝  ╚═╝\r\n                         \r\n");
            Console.WriteLine("\r\n██████╗ ██╗      █████╗ ██╗   ██╗██╗███╗   ██╗ ██████╗ ██╗\r\n██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝██║████╗  ██║██╔════╝ ██║\r\n██████╔╝██║     ███████║ ╚████╔╝ ██║██╔██╗ ██║██║  ███╗██║\r\n██╔═══╝ ██║     ██╔══██║  ╚██╔╝  ██║██║╚██╗██║██║   ██║╚═╝\r\n██║     ███████╗██║  ██║   ██║   ██║██║ ╚████║╚██████╔╝██╗\r\n╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝\r\n                                                          \r\n");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }

    public interface IMagicalCharacter {
        void CastSpell();
        void DisplayCharacterInfo();
    }

    public struct CharacterAttributes {
        public string Name;
        public string AgeGroup;
        public string Role;
        public string BodyType;
        public string SkinTone;
        public string EyeColor;
        public string FacialMarkings;
        public string FacialExpression;
        public string Hairstyle;
        public string HairColor;
        public string SplashBackground;
        public string LipColor;
        public string Eyeshadow;
        public string Eyeliner;
        public string Eyebrow;
        public string Blush;
        public string Dress;
        public string Top;
        public string Bottom;
        public string Footwear;
        public string MainWeapon;
        public string MagicalJewelry;
        public bool MagicalAura;
        public int[] RitualPoints;
        public string ElementalAffinity;
        public string SupportSpell;
        public string MagicalCompanion;
    }

    public abstract class Character : IMagicalCharacter {
        public CharacterAttributes Attributes;

        protected Character(string name) {
            Attributes.Name = name;
            Attributes.RitualPoints = new int[5];
        }

        public static Character CreateCharacter()
        {
            Console.Clear();
            string name = CharacterUtilities.GetCharacterName();

            string connectionString = "server=localhost;user=root;database=dressup;password=";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string checkNameQuery = "SELECT COUNT(*) FROM characters WHERE name = @name";
                MySqlCommand checkNameCommand = new MySqlCommand(checkNameQuery, connection);
                checkNameCommand.Parameters.AddWithValue("@name", name);

                int nameCount = Convert.ToInt32(checkNameCommand.ExecuteScalar());

                if (nameCount > 0)
                {
                    Console.WriteLine("\nThis character name is already in use. Please choose a different name.");
                    Console.ReadKey();
                    return CreateCharacter();
                }
            }

            Character character;
            string role = CharacterUtilities.GetRole();

            if (role == "Witch")
            {
                character = new Witch(name);
            }
            else
            {
                character = new Wizard(name);
            }

            character.Attributes.Role = role;
            character.Attributes.AgeGroup = CharacterUtilities.GetAgeGroup();
            character.Attributes.BodyType = CharacterUtilities.GetBodyType();
            character.Attributes.SkinTone = CharacterUtilities.GetSkinTone();
            character.Attributes.EyeColor = CharacterUtilities.GetEyeColor();
            character.Attributes.FacialMarkings = CharacterUtilities.GetFacialMarkings();
            character.Attributes.FacialExpression = CharacterUtilities.GetFacialExpression();
            character.Attributes.Hairstyle = CharacterUtilities.GetHairstyle();
            character.Attributes.HairColor = CharacterUtilities.GetHairColor();
            character.Attributes.SplashBackground = CharacterUtilities.GetSplashBackground();
            character.Attributes.LipColor = CharacterUtilities.GetLipColor();
            character.Attributes.Eyeshadow = CharacterUtilities.GetEyeshadow();
            character.Attributes.Eyeliner = CharacterUtilities.GetEyeliner();
            character.Attributes.Eyebrow = CharacterUtilities.GetEyebrow();
            character.Attributes.Blush = CharacterUtilities.GetBlush();

            character.Attributes.Dress = CharacterUtilities.GetClothingChoice(role, "Dresses");
            character.Attributes.Top = CharacterUtilities.GetClothingChoice(role, "Tops");
            character.Attributes.Bottom = CharacterUtilities.GetClothingChoice(role, "Bottoms");
            character.Attributes.Footwear = CharacterUtilities.GetClothingChoice(role, "Footwear");

            string[] mainWeaponOptions = role == "Witch"
                ? new[] { "Enchanted Staff", "Crystal Wand", "Obsidian Dagger", "Silver Scepter", "Mystic Orb" }
                : new[] { "Elemental Staff", "Dragon Wand", "Rune Sword", "Ancient Tome", "Celestial Rod" };

            string[] magicalJewelryOptions = new[] { "Moonstone Pendant", "Starlight Ring", "Elemental Bracelet", "Celestial Necklace", "Protection Amulet" };

            character.Attributes.MainWeapon = CharacterUtilities.GetMagicalAccessory("Main Weapon", mainWeaponOptions);
            character.Attributes.MagicalJewelry = CharacterUtilities.GetMagicalAccessory("Magical Jewelry", magicalJewelryOptions);

            character.Attributes.MagicalAura = CharacterUtilities.GetMagicalAura();
            character.Attributes.RitualPoints = CharacterUtilities.AllocateRitualPoints();
            character.Attributes.ElementalAffinity = CharacterUtilities.GetElementalAffinity();
            character.Attributes.SupportSpell = CharacterUtilities.GetSupportSpell();
            character.Attributes.MagicalCompanion = CharacterUtilities.GetMagicalCompanion();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO characters 
            (name, age, role, bodytype, skintone, eyecolor, markings, expression, hairstyle, haircolor, background, lipcolor, eyeshadow, eyeliner, eyebrow, blush, dress, top, bottom, footwear, weapon, jewelry, aura, protection, healing, divination, curse, manifestation, affinity, spell, companion) 
            VALUES 
            (@name, @age, @role, @bodytype, @skintone, @eyecolor, @markings, @expression, @hairstyle, @haircolor, @background, @lipcolor, @eyeshadow, @eyeliner, @eyebrow, @blush, @dress, @top, @bottom, @footwear, @weapon, @jewelry, @aura, @protection, @healing, @divination, @curse, @manifestation, @affinity, @spell, @companion)";

                command.Parameters.AddWithValue("@name", character.Attributes.Name);
                command.Parameters.AddWithValue("@age", character.Attributes.AgeGroup);
                command.Parameters.AddWithValue("@role", character.Attributes.Role);
                command.Parameters.AddWithValue("@bodytype", character.Attributes.BodyType);
                command.Parameters.AddWithValue("@skintone", character.Attributes.SkinTone);
                command.Parameters.AddWithValue("@eyecolor", character.Attributes.EyeColor);
                command.Parameters.AddWithValue("@markings", character.Attributes.FacialMarkings);
                command.Parameters.AddWithValue("@expression", character.Attributes.FacialExpression);
                command.Parameters.AddWithValue("@hairstyle", character.Attributes.Hairstyle);
                command.Parameters.AddWithValue("@haircolor", character.Attributes.HairColor);
                command.Parameters.AddWithValue("@background", character.Attributes.SplashBackground);
                command.Parameters.AddWithValue("@lipcolor", character.Attributes.LipColor);
                command.Parameters.AddWithValue("@eyeshadow", character.Attributes.Eyeshadow);
                command.Parameters.AddWithValue("@eyeliner", character.Attributes.Eyeliner);
                command.Parameters.AddWithValue("@eyebrow", character.Attributes.Eyebrow);
                command.Parameters.AddWithValue("@blush", character.Attributes.Blush);
                command.Parameters.AddWithValue("@dress", character.Attributes.Dress);
                command.Parameters.AddWithValue("@top", character.Attributes.Top);
                command.Parameters.AddWithValue("@bottom", character.Attributes.Bottom);
                command.Parameters.AddWithValue("@footwear", character.Attributes.Footwear);
                command.Parameters.AddWithValue("@weapon", character.Attributes.MainWeapon);
                command.Parameters.AddWithValue("@jewelry", character.Attributes.MagicalJewelry);
                command.Parameters.AddWithValue("@aura", character.Attributes.MagicalAura);
                command.Parameters.AddWithValue("@protection", character.Attributes.RitualPoints[0]);
                command.Parameters.AddWithValue("@healing", character.Attributes.RitualPoints[1]);
                command.Parameters.AddWithValue("@divination", character.Attributes.RitualPoints[2]);
                command.Parameters.AddWithValue("@curse", character.Attributes.RitualPoints[3]);
                command.Parameters.AddWithValue("@manifestation", character.Attributes.RitualPoints[4]);
                command.Parameters.AddWithValue("@affinity", character.Attributes.ElementalAffinity);
                command.Parameters.AddWithValue("@spell", character.Attributes.SupportSpell);
                command.Parameters.AddWithValue("@companion", character.Attributes.MagicalCompanion);

                command.ExecuteNonQuery();
            }

            return character;
        }

        public virtual void DisplayCharacterInfo() {
            Console.Clear();
            Console.WriteLine($"Character Name: {Attributes.Name}");
            Console.WriteLine($"Age Group: {Attributes.AgeGroup}");
            Console.WriteLine($"Role: {Attributes.Role}");
            Console.WriteLine($"Body Type: {Attributes.BodyType}");
            Console.WriteLine($"Skin Tone: {Attributes.SkinTone}");
            Console.WriteLine($"Eye Color: {Attributes.EyeColor}");
            Console.WriteLine($"Facial Markings: {Attributes.FacialMarkings}");
            Console.WriteLine($"Facial Expression: {Attributes.FacialExpression}");
            Console.WriteLine($"Hairstyle: {Attributes.Hairstyle}");
            Console.WriteLine($"Hair Color: {Attributes.HairColor}");
            Console.WriteLine($"Splash Background: {Attributes.SplashBackground}");
            Console.WriteLine($"Lip Color: {Attributes.LipColor}");
            Console.WriteLine($"Eyeshadow: {Attributes.Eyeshadow}");
            Console.WriteLine($"Eyeliner: {Attributes.Eyeliner}");
            Console.WriteLine($"Eyebrow: {Attributes.Eyebrow}");
            Console.WriteLine($"Blush: {Attributes.Blush}");
            Console.WriteLine($"Dress: {Attributes.Dress}");
            Console.WriteLine($"Top: {Attributes.Top}");
            Console.WriteLine($"Bottom: {Attributes.Bottom}");
            Console.WriteLine($"Footwear: {Attributes.Footwear}");
            Console.WriteLine($"Main Weapon: {Attributes.MainWeapon}");
            Console.WriteLine($"Magical Jewelry: {Attributes.MagicalJewelry}");
            Console.WriteLine($"Magical Aura: {(Attributes.MagicalAura ? "Yes" : "No")}");
            Console.WriteLine($"Protection Ritual Points: {Attributes.RitualPoints[0]}");
            Console.WriteLine($"Healing Ritual Points: {Attributes.RitualPoints[1]}");
            Console.WriteLine($"Divination Ritual Points: {Attributes.RitualPoints[2]}");
            Console.WriteLine($"Curse Ritual Points: {Attributes.RitualPoints[3]}");
            Console.WriteLine($"Manifestation Ritual Points: {Attributes.RitualPoints[4]}");
            Console.WriteLine($"Elemental Affinity: {Attributes.ElementalAffinity}");
            Console.WriteLine($"Support Spell: {Attributes.SupportSpell}");
            Console.WriteLine($"Magical Companion: {Attributes.MagicalCompanion}");
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
        public abstract void CastSpell();
    }

    public class Witch : Character {
        public Witch(string name) : base(name) {
            Attributes.Role = "Witch";
        }

        public override void CastSpell() {
            Console.WriteLine($"{Attributes.Name} casts a powerful witch spell!");
        }
    }

    public class Wizard : Character {
        public Wizard(string name) : base(name) {
            Attributes.Role = "Wizard";
        }

        public override void CastSpell() {
            Console.WriteLine($"{Attributes.Name} casts a mighty wizard spell!");
        }
    }

    public static class CharacterUtilities {
        public static string GetCharacterName() {
            string characterName = "";
            bool validName = false;

            while (!validName) {
                Console.Clear();
                Console.WriteLine("Please enter your character name (2-15 characters, special characters allowed): ");
                characterName = Console.ReadLine();

                if (characterName.Length >= 2 && characterName.Length <= 15) {
                    validName = true;
                } else {
                    Console.WriteLine("The character name must be between 2 and 15 characters long.");
                }
            }
            return characterName;
        }

        public static string GetRole() {
            return GetChoice("Choose your role:", new[] { "Witch", "Wizard" });
        }

        public static string GetAgeGroup() {
            return GetChoice("Choose your age group:", new[] { "Toddler", "Young", "Middle-aged", "Elderly", "Ancient" });
        }

        public static string GetBodyType() {
            return GetChoice("Choose your body type:", new[] { "Slim", "Average", "Curvy", "Muscular", "Petite", "Tall", "Short", "Athletic", "Wide" });
        }

        public static string GetSkinTone() {
            return GetChoice("Choose your skin tone:", new[] { "Fair", "Medium", "Tan", "Olive", "Pale", "Glowing" });
        }

        public static string GetEyeColor() {
            return GetChoice("Choose your eye color:", new[] { "Black", "Brown", "Hazel", "Green", "Blue", "Gray", "Amber", "Violet" });
        }

        public static string GetFacialMarkings() {
            return GetChoice("Choose your facial markings:", new[] { "None", "Scars", "Birthmarks", "Freckles", "Moles" });
        }

        public static string GetFacialExpression() {
            return GetChoice("Choose your facial expression:", new[] { "Smiling", "Serious", "Neutral", "Mysterious" });
        }

        public static string GetHairstyle() {
            return GetChoice("Choose your hairstyle:", new[] { "Long", "Short", "Curly", "Straight", "Braided", "Bald", "Slicked-back", "Tied-back" });
        }

        public static string GetHairColor() {
            return GetChoice("Choose your hair color:", new[] { "Brown", "Black", "Blonde", "Fiery Red", "Midnight Black", "Glowing Silver", "Enchanted Blue", "Radiant Purple" });
        }

        public static string GetSplashBackground() {
            return GetChoice("Choose your splash background:", new[] { "Enchanted Forest", "Witch’s Potion Room", "Wizard’s Tower", "Moonlit Graveyard", "Mystical Library", "Crystal Cavern", "Magical School Courtyard", "Celestial Sky", "Haunted Island" });
        }

        public static string GetLipColor() {
            return GetChoice("Choose your lip color:", new[] { "Deep Black", "Blood Red", "Crimson", "Dark Plum", "Nude Beige", "Burnt Orange", "Forest Green", "Midnight Blue", "Soft Rose", "Gold", "Copper", "Wine Red", "Lavender" });
        }

        public static string GetEyeshadow() {
            return GetChoice("Choose your eyeshadow:", new[] { "None", "Light Pink", "Dark Purple", "Shimmering Gold", "Ocean Blue", "Forest Green", "Smoky Gray", "Bright Yellow" });
        }

        public static string GetEyeliner() {
            return GetChoice("Choose your eyeliner:", new[] { "None", "Black", "Brown", "Colored", "Winged", "Cat Eye" });
        }

        public static string GetEyebrow() {
            return GetChoice("Choose your eyebrow style:", new[] { "Natural", "Arched", "Straight", "Thin", "Thick" });
        }

        public static string GetBlush() {
            return GetChoice("Choose your blush:", new[] { "None", "Light Pink", "Peach", "Rose", "Bronze", "Plum" });
        }

        public static string GetMagicalCompanion() {
            return GetChoice("Select your magical companion:", new[] { "Cat", "Owl", "Frog", "Dragon", "Phoenix", "Wolf", "Bat", "Fairy" });
        }

        public static string GetSupportSpell() {
            return GetChoice("Select your support spell:", new[] { "Telekinesis", "Potion Brewing", "Shape-shifting", "Illusion Magic", "Healing Magic", "Teleportation", "Enchantment", "Mind Control" });
        }

        public static string GetElementalAffinity() {
            return GetChoice("Select your elemental affinity:", new[] { "Fire", "Water", "Earth", "Air" });
        }

        public static int[] AllocateRitualPoints() {
            int totalPoints = 10;
            int[] ritualPoints = new int[5];
            string[] ritualNames = { "Protection", "Healing", "Divination", "Curse", "Manifestation" };

            while (totalPoints > 0) {
                Console.Clear();
                Console.WriteLine("Allocate your ritual points (total points remaining: " + totalPoints + "):");
                
                for (int i = 0; i < ritualNames.Length; i++) {
                    Console.WriteLine($"{i + 1}. {ritualNames[i]} (Current Points: {ritualPoints[i]})");
                }
                
                Console.Write("Choose a ritual to allocate a point (1-5) or enter 0 to finish: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 0 && choice <= 5) {
                    if (choice == 0) {
                        break;
                    } else if (choice >= 1 && choice <= 5) {
                        int ritualIndex = choice - 1;
                        if (ritualPoints[ritualIndex] < 3) {
                            ritualPoints[ritualIndex]++;
                            totalPoints--;
                        } else {
                            Console.WriteLine("Maximum points for this ritual reached. Choose another.");
                        }
                    }
                } else {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
            return ritualPoints;
        }

        public static string GetClothingChoice(string role, string category) {
            string choice = "";
            string[] options;

            if (role == "Witch") {
                switch (category) {
                    case "Dresses":
                        options = new[] {"Traditional", "Nature", "Gothic", "Vintage", "Celestial", "Cottagecore", "Sea", "Festival", "Shadow", "Elemental"};
                        break;
                    case "Tops":
                        options = new[] {"Flowy Bell Sleeve Tops", "Corset", "Off-Shoulder", "High Neck Blouses", "Crop Tops with Prints", "Tunic Tops", "Sheer Layered Tops", "Wrap Tops"};
                        break;
                    case "Bottoms":
                        options = new[] {"Long Flowing Skirts", "Asymmetrical Skirts", "High-Waisted Skirts", "Layered Tulle Skirt", "Wide Leg Pants", "Harem Pants", "Fitted Pants", "Wrap Skirts", "Leggings"};
                        break;
                    case "Footwear":
                        options = new[] {"Pointed Boots", "Lace-up Boots", "Ballet Flats", "Ankle Boots", "Knee-High Boots", "Slippers", "Magical Sandals", "Wooden Sandals" };
                        break;
                    default:
                        options = new string[0];
                        break;
                }
            } else {
                switch (category) {
                    case "Dresses":
                        options = new[] {"Traditional Robes", "High Collared Robes", "Hooded Cloaks", "Layered Robes", "Celestial Robes", "Elemental Robes", "Academic Robes", "Adventurer"};
                        break;
                    case "Tops":
                        options = new[] {"Tunics", "High Collared Shirts", "Robe-Style Tops", "Layered Vests", "Alchemist Tops", "Embroidered Shirts", "Hooded Tops", "Celestial Tops", "Asymmetrical Wrap Tops", "Armored Tops"};
                        break;
                    case "Bottoms":
                        options = new[] {"Loose Fitting Trousers", "High Waisted Pants", "Layered Skirt/Pants", "Tapered Pants", "Embroidered Pants", "Robe-Like Wrap Bottom", "Leather Pants", "Harem Pants", "Utility Pants", "Wide Leg Pants"};
                        break;
                    case "Footwear":
                        options = new[] {"Robed Boots", "Boots with Buckles", "Travel Boots", "Slippers of Comfort", "Pointed Shoes", "Heavy Leather Boots", "Mage Sandals", "Enchanted Boots"};
                        break;
                    default:
                        options = new string[0];
                        break;
                }
            }

            bool validChoice = false;
            while (!validChoice) {
                Console.Clear();
                Console.WriteLine($"Choose your {category}:");

                for (int i = 0; i < options.Length; i++) {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }

                Console.Write("Enter the number of your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int index) && index > 0 && index <= options.Length) {
                    choice = options[index - 1];
                    validChoice = true;
                } else {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
            return choice;
        }

        public static string GetMagicalAccessory(string category, string[] options) {
            string choice = "";
            bool validChoice = false;

            while (!validChoice) {
                Console.Clear();
                Console.WriteLine($"Choose your {category}:");
                for (int i = 0; i < options.Length; i++) {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }

                Console.Write("Enter the number of your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int index) && index > 0 && index <= options.Length) {
                    choice = options[index - 1];
                    validChoice = true;
                } else {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
            return choice;
        }

        public static bool GetMagicalAura() {
            bool validChoice = false;
            bool magicalAura = false;

            while (!validChoice) {
                Console.Clear();
                Console.WriteLine("Do you want to have Magical Aura?");
                Console.WriteLine("1. Yes: Faster spell cooldown during battle, but easily targeted by enemies");
                Console.WriteLine("2. No: Boosted stealth for less damage received, but longer time to cast spells");
                Console.Write("Enter the number of your choice (1-2): ");
                string input = Console.ReadLine();

                if (input == "1") {
                    magicalAura = true;
                    validChoice = true;
                } else if (input == "2") {
                    magicalAura = false;
                    validChoice = true;
                } else {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
            return magicalAura;
        }

        private static string GetChoice(string prompt, string[] options) {
            string choice = "";
            bool validChoice = false;

            while (!validChoice)
            {
                Console.Clear();
                Console.WriteLine(prompt);

                for (int i = 0; i < options.Length; i++) {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }

                Console.Write("Enter the number of your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int index) && index > 0 && index <= options.Length) {
                    choice = options[index - 1];
                    validChoice = true;
                } else {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
            return choice;
        }
    }
}