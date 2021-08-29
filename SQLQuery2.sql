drop table if exists Genre
create table Genre(
    GenreId int primary key identity(1,1),
    GenreName nvarchar(50)

)
drop table if exists Album
create table Album(
    AlbumId int primary key identity(1,1),
    Title nvarchar(25),
    ReleaseDate Datetime,
    Artist nvarchar(25),
    Price Double PRECISION,
    GenreId int foreign key references Genres(GenreId)
)

insert into Genres values (  'Pop')
insert into Genres values (  'Rock') 
insert into Genres values (   'Hip Hop')
insert into Genres values (   'Jazz')
insert into Genres values (   'Punk')
insert into Genres values (   'Rap') 
insert into Genres values (  'R&B')
insert into Genres values (  'Country')
insert into Genres values (   'Latin')
go
insert into Albums values( 'Twenty File', '2015/11/20', 'Adele',9.99,1)
insert into Albums values( 'Nineteen Eighty-Nine', '2014/10/27', 'Taylor Swift',10.99,1)
insert into Albums values( 'A million', '2016/09/30', 'Bon Iver',9.99,2)
insert into Albums values( 'Meteora', '2003/03/25', 'Linkin Park',7.99,2)
insert into Albums values( 'Nevermind', '1991/09/24', 'Nivarna',9.99,2)
insert into Albums values( 'To Pimp a Butterfly', '2015/03/15', 'Kendrick Lamar',8.99,3)
insert into Albums values( 'Comes Away With Me', '2002/02/26', 'Norah Jones',6.99,4)
insert into Albums values( 'Kind of Blues', '1959/08/17', 'Miles Davids',7.99,4)
insert into Albums values( 'Dookie', '1994/02/01', 'Green Day',8.99,5)
insert into Albums values( 'Relapse', '2009/05/15', 'Eminem',9.99,6)
insert into Albums values( 'Get Rich or Die', '2003/02/06', 'Tryin',7.99,6)
insert into Albums values( 'Blonde', '2006/08/20', 'Frank Oceans',8.99,7)
insert into Albums values( 'Love, Marriage & Divorce', '2004/02/04', 'Babyface & Toni Braxton',9.99,7)
insert into Albums values( 'Lemonade', '2016/04/23', 'Beyonce',11.99,1)
insert into Albums values( 'Purpose', '2015/11/13', 'Justin Bieber',9.99,1)
insert into Albums values( 'Los Duo', '2015/02/10', 'Joan Gabriel',7.99,9)
insert into Albums values( 'They Don’t Know', '2006/09/09', 'Jason Aldean',9.99,9)