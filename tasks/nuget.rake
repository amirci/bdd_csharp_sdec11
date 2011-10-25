include FileUtils

namespace :setup do
	desc "Setup dependencies for nuget packages"
	task :dep do
		FileList["**/packages.config"].each do |file|
			sh "nuget install #{file} /OutputDirectory Packages"
		end

		setup_os
	end
end

def setup_os(target = nil)
	target ||= File.exist?('c:\Program Files (x86)') ? 64 : 32
	puts "**** Setting up OS #{target} bits"
	files = FileList["Packages/SQLitex64.1.0.66/lib/#{target}/*.dll"]
	puts "**** Copying files #{files}"
	FileUtils.cp(files, "Packages/SQLitex64.1.0.66/lib")
end