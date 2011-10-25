require 'albacore'

namespace :build do

	desc "Build the project"
	msbuild :all, [:config] => ["setup"] do |msb, args|
		msb.properties :configuration => args[:config] || :Debug
		msb.targets :Build
		msb.solution = FileList['*.sln'].first
	end

	desc "Rebuild the project"
	task :re => ["clean", "build:all"]
end