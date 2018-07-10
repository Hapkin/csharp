// -----------------------------------------------------------------------------
//  <copyright file="ObservableObjectTests.cs" company="DCOM Engineering, LLC">
//      Copyright (c) DCOM Engineering, LLC.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------
namespace Tests.UnitTests
{
    using EnterpriseMVVM.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObservableObjectTests
    {
        [TestMethod]
        public void PropertyChangedEventHandlerIsRaised()
        {
            var obj = new StubObservableObject();

            bool raised = false;

            obj.PropertyChanged += (sender, e) =>
                                   {
                                       Assert.IsTrue(e.PropertyName == "ChangedProperty");
                                       raised = true;
                                   };

            obj.ChangedProperty = "Some Value";

            if (!raised) Assert.Fail("PropertyChanged was never invoked.");
        }

        private class StubObservableObject : ObservableObject
        {
            private string changedProperty;

            public string ChangedProperty
            {
                get { return this.changedProperty; }
                set
                {
                    this.changedProperty = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}