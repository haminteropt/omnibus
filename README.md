# omnibus
ReST server to talk to OmniRig

This is still very much working in process.

Swagger API docs
http://localhost:7300/swagger/

Setting up self-Hosting
https://codeopinion.com/self-host-asp-net-web-api/

Run as a service.
https://github.com/luisperezphd/RunAsService

## Building

Must add Interop.OmniRig.dll to reference to build, which can be found in the externdlls folder.

Added support for TopSelf service framework.  It will run under the debugger as well as an installed service.  
However it throws an exception when trying to run as a stand alone console app.

## Installing as a service.

As admin 

### Install
 omnirigbus install

### Uninstall

omnirigbus uninstall

### Help

omnirigbus --help

Not sure why yet, but --autostart doesn't work for me.  



