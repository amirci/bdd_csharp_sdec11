require 'rubygems'    

sh "bundle install --system"
Gem.clear_paths

Dir["tasks/**/*.rake"].sort.each { |ext| load ext }

