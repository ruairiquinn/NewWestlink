using System;
using System.Web.Mvc;
using StructureMap;

namespace NewWestlink.Infrastructure.StructureMapArtifacts
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if(controllerType == null)
                return null;

            return GetControllerInstance(controllerType);
        }

        private IController GetControllerInstance(Type controllerType)
        {
            try
            {
                return ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch (StructureMapException)
            {
                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw;
            }
        }
    }
}