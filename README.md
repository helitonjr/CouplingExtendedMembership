Coupling - RavenDB-DDD-ExtendedMembershipProvider
===========

A basic PoC to demonstrate using the ExtendedMembershipProvider with use of DDD and RaveDB memberships data management and storage

Its a bit rough and ready at the moment, much is missing but most of the basic concepts are included providing a base to extend further.

Configuration<br />
Modify the web.config of the web application to inlcude the following sections. 
The key property to modify is the connectionString to ensure points to your instance of RaveDB.
<pre>
<configuration>
  <connectionStrings>
    <add name="CouplingDataStore" connectionString="URL=http://localhost:8080;Database=Coupling" />
  </connectionStrings>

  <system.web>
    <membership defaultProvider="CouplingMembershipProvider" userIsOnlineTimeWindow="20">
      <providers>
        <clear />
        <add name="CouplingMembershipProvider" type="Coupling.Web.ApplicationServices.Memberships.CouplingExtendedMembershipProvider, Coupling.Web.ApplicationServices, Version=1.0.0.0, Culture=neutral" connectionStringName="CouplingDataStore"
             applicationName="Coupling" requiresQuestionAndAnswer="false" enablePasswordReset="true" enablePasswordRetrieval="false" />
      </providers>
    </membership>
  </system.web>
</configuration>
</pre>

Web Application Integration<br />
To integration into your own web application see the sample Coupling.Web package.<br>
Structuremap has been used for Dependency Injection. Each package contains a DepenencyResolution folder with a registry for injectable components.


