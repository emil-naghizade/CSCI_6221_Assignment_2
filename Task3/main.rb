# Base class LibraryItem
class LibraryItem
  attr_accessor :title, :author, :publication_year

  def initialize(title, author, publication_year)
    @title = title
    @author = author
    @publication_year = publication_year
  end

  # Shared method to be overridden by derived classes
  def display_info
    puts "Title: #{@title}"
    puts "Author: #{@author}"
    puts "Publication Year: #{@publication_year}"
  end
end

# Derived class Book
class Book < LibraryItem
  attr_accessor :genre

  def initialize(title, author, publication_year, genre)
    super(title, author, publication_year)
    @genre = genre
  end

  def display_info
    super
    puts "Genre: #{@genre}"
  end
end

# Derived class DVD
class DVD < LibraryItem
  attr_accessor :director

  def initialize(title, author, publication_year, director)
    super(title, author, publication_year)
    @director = director
  end

  def display_info
    super
    puts "Director: #{@director}"
  end
end

# Derived class CD
class CD < LibraryItem
  attr_accessor :artist

  def initialize(title, author, publication_year, artist)
    super(title, author, publication_year)
    @artist = artist
  end

  def display_info
    super
    puts "Artist: #{@artist}"
  end
end

# Library class to manage a collection of LibraryItems
class Library
  def initialize
    @items = []
  end

  def add_item(item)
    @items << item
    puts "#{item.title} has been added to the library."
  end

  def remove_item(title)
    @items.delete_if { |item| item.title == title }
    puts "#{title} has been removed from the library."
  end

  def display_all_items
    @items.each do |item|
      item.display_info
      puts "--------------------------------"
    end
  end
end

# Main Program
library = Library.new

# Adding items to the library
book = Book.new("Concepts of Programming Languages", "Robert Sebesta", 2015, "Programming")
dvd = DVD.new("Inception", "Christopher Nolan", 2010, "Nolan")
cd = CD.new("A Day at the Races", "Queen", 1976, "Freddie Mercury")

library.add_item(book)  
library.add_item(dvd)
library.add_item(cd)

# Display information for each item
puts "Displaying individual item information:"
book.display_info
puts "--------------------------------"
dvd.display_info
puts "--------------------------------"
cd.display_info
puts "--------------------------------"

# Display all items in the library
library.display_all_items
