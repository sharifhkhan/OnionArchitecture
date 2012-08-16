using System;
using TechTalk.SpecFlow;

namespace Onion.Specs
{
    [Binding]
    public class ViewProductsByCategoriesSteps
    {
        [Given(@"I have selected a category")]
        public void GivenIHaveSelectedACategory()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press show products")]
        public void WhenIPressShowProducts()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be a list of products for selected category")]
        public void ThenTheResultShouldBeAListOfProductsForSelectedCategory()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
