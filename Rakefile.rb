require 'rubygems'    

sh "bundle install --system"
Gem.clear_paths

require 'albacore'
require 'rake/clean'
require 'git'
require 'set'

include FileUtils

solution_file = FileList["*.sln"].first
build_file = FileList["*.msbuild"].first
www_proj_file = FileList["**/MovieLibrary.WebSite/*.csproj"].first

project_name = "MovieLibrary"
commit = Git.open(".").log.first.sha[0..10] rescue 'na'
version = IO.readlines('VERSION')[0] rescue "0.0.0.0"
build_folder = File.join('.', 'build', 'www')
deploy_folder = "c:/temp/build/#{project_name}.#{version}_#{commit}"
merged_folder = "#{deploy_folder}/merged"

CLEAN.include("main/**/bin", "main/**/obj", "test/**/obj", "test/**/bin", "gem/lib/**", ".svn")

CLOBBER.include("**/_*", "**/.svn", "packages/*", "lib/*", "**/*.user", "**/*.cache", "**/*.suo", "*.docstates", "build", "*.xml")

desc 'Default build'
task :default => ["build:all"]

desc 'Setup requirements to build and deploy'
task :setup => ["setup:dep"]

desc "Publish the website"
task :deploy => ["deploy:all"]

desc "Run all unit tests"
task :test => ["test:unit"]

namespace :setup do
	desc "Setup dependencies for nuget packages"
	task :dep do
		FileList["**/packages.config"].each do |file|
			sh "nuget install #{file} /OutputDirectory Packages"
		end

		setup_os
	end
end

namespace :build do

	desc "Build the project"
	msbuild :all, [:config] => ["setup"] do |msb, args|
		msb.properties :configuration => args[:config] || :Debug
		msb.targets :Build
		msb.solution = solution_file
	end

	desc "Rebuild the project"
	task :re => ["clean", "build:all"]
end

namespace :test do

	desc "Run unit tests"
	nunit :unit => ["build:all"] do |nunit|
		nunit.command = "packages/NUnit.2.5.9.10348/Tools/nunit-console.exe"
		nunit.assemblies FileList["test/unit/**/bin/debug/*Tests.dll"]
	end

	desc "Run acceptance tests"
	nunit :acceptance => ["build:all"] do |nunit|
		nunit.command = "packages/NUnit.2.5.10.11092/Tools/nunit-console.exe"
		nunit.assemblies FileList["test/acceptance/**/bin/debug/*Tests.dll"]
	end
end

def setup_os(target = nil)
	target ||= File.exist?('c:\Program Files (x86)') ? 64 : 32
	puts "**** Setting up OS #{target} bits"
	files = FileList["Packages/SQLitex64.1.0.66/lib/#{target}/*.dll"]
	puts "**** Copying files #{files}"
	FileUtils.cp(files, "Packages/SQLitex64.1.0.66/lib")
end

