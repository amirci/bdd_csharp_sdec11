require 'albacore'

namespace :test do

	desc "Run unit tests"
	nunit :unit => ["build:all"] do |nunit|
		nunit.command = "packages/NUnit.2.5.10.11092/Tools/nunit-console.exe"
		nunit.assemblies FileList["test/unit/**/bin/debug/*Tests.dll"]
	end

	desc "Run acceptance tests"
	nunit :acceptance => ["build:all"] do |nunit|
		nunit.command = "packages/NUnit.2.5.10.11092/Tools/nunit-console.exe"
		nunit.assemblies FileList["test/acceptance/**/bin/debug/*Tests.dll"]
	end
end