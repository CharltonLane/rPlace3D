"""
This script takes the compact data provided by user 'golslyr' here 
# https://www.reddit.com/r/place/comments/txvk2d/comment/i3utewb/?utm_source=share&utm_medium=web2x&context=3
and trims it down further by removing timestamps and user hashes.

The timestamps are used to sort the data chronologically, however they are not saved out to the resulting file.

Since the data is still quite large, you'll need to leave this running for a while and have at least 16GB of RAM.
"""


import os

place_data_file_dir = "./2022-compact.csv"

output_file = "./cleanData.txt"


def run():
    final_data = []

    i = 0

    has_skipped_first_line = False

    #print("Checking num lines in file")
    #num_lines = sum(1 for line in open(place_data_file_dir))
    #print("Read", num_lines, "lines")

    print("Starting read")

    assert os.path.isfile(place_data_file_dir)
    with open(place_data_file_dir, 'r') as data_file:
        for line in data_file:

            if not has_skipped_first_line:
                has_skipped_first_line = True
                continue

            split_line = line.split(",")

            time = ((int)(split_line[0]) - 1648810000000) # This is not needed, just trying to make these numbers smaller to hopefully use less memory. Not sure if it makes a difference but worth a shot.

            color = split_line[2]
            position = ",".join([s.replace('"', "") for s in split_line[3:]])

            final_data.append((time, color + "|" + position))

            if (i % 1000000 == 0):
                print("Read",i,"lines")

            i += 1


    print("Starting Sort")
    final_data.sort(key=lambda tup: tup[0])


    print("Writing to file")
    with open(output_file, 'w') as file:
        for line in final_data:
            file.write(line[1])
        print("All done writing data!")
        

if __name__ == "__main__":
    run()