require 'rake/clean'

CLEAN.include("main/**/bin", "main/**/obj", "test/**/obj", "test/**/bin", "gem/lib/**", ".svn")

CLOBBER.include("packages/*", "lib/*", "**/*.user", "**/*.cache", "**/*.suo", "*.docstates", "build", "*.xml")

desc 'Default build'
task :default => ["build:all"]

desc 'Setup requirements to build and deploy'
task :setup => ["setup:dep"]

desc "Publish the website"
task :deploy => ["deploy:all"]

desc "Run all unit tests"
task :test => ["test:unit"]




