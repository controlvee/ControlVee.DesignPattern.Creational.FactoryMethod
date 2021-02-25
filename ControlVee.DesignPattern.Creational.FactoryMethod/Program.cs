namespace ControlVee.DesignPattern.Creational.FactoryMethod
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /* 
        Summary:  Define an interface for creating an object, but let subclasses 
        decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.

        Participants -
        The classes and objects participating in this pattern are:

            Product  (Page)
                - defines the interface of objects the factory method creates

            ConcreteProduct  (SkillsPage, EducationPage, ExperiencePage)
                - constructs and assembles parts of the product by implementing the Builder interface
                - defines and keeps track of the representation it creates
                - provides an interface for retrieving the product

            Creator  (Document)
                - declares the factory method, which returns an object of type Product. 
                Creator may also define a default implementation of the factory method that returns a 
                default ConcreteProduct object
                - may call the factory method to create a Product object

            ConcreteCreator  (Report, Resume)
                - overrides the factory method to return an instance of a ConcreteProduct
    */
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Note: Ctors call Factory Method!
            Document[] docs = new Document[2];

            docs[0] = new Resume();
            docs[1] = new Report();

            // Display pages.
            foreach (Document doc in docs)
            {
                Console.WriteLine($"\n{ doc.GetType().Name } includes --");
                foreach (Page page in doc.Pages)
                {
                    Console.WriteLine($"\t{ page.GetType().Name }");
                }
            }

            // Wait.
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Products - abstract and concrete.
    /// </summary>
    abstract class Page
    {
    }

    class SkillsPage : Page 
    { 
    }

    class EducationPage : Page 
    { 
    }

    class ExperiencePage : Page
    {
    }

    class IntroductionPage : Page
    {
    }

    class ResultsPage : Page
    {
    }

    class ConclusionPage : Page
    {
    }

    class SummaryPage : Page
    {
    }

    class BibliographyPage : Page
    {
    }
    
    /// <summary>
    /// The Creator class.
    /// </summary>
    abstract class Document
    {
        private List<Page> _pages = new List<Page>();

        public List<Page> Pages
        {
            get { return _pages; }
        }

        // The ctr calls the abstract Factory method.
        public Document()
        {
            // What is the purpose of this method
            // in the ctor?
            this.CreatePages();
        }

        // Why doesn't this have an empty body {}?
        // Why is this needed? Why not just create a method 
        // in the derived class?  Is it for enforcement?
        public abstract void CreatePages();
    }

    class Resume : Document
    {
        public override void CreatePages()
        {
            base.Pages.Add(new SkillsPage());
            base.Pages.Add(new EducationPage());
            base.Pages.Add(new ExperiencePage());
        }
    }

    class Report : Document
    {
        // Factory Method implementation.
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }
}
