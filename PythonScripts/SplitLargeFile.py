"""
Split the file into chunks of 5M lines
This is done so that Unity doesn't die trying to load a 2GB file into RAM.
"""


import os

large_file_dir = "./cleanData.txt"

output_file_name = "placeData"


def run():
    final_data = []

    file_number = 0
    i = 0

    print("Starting read")

    assert os.path.isfile(large_file_dir)
    with open(large_file_dir, 'r') as data_file:
        for line in data_file:

            # print(line)
            final_data.append(line)

            if ((i+1) % 5000000 == 0):
                print("Writing to file", file_number)
                with open("./" + output_file_name + str(file_number) + ".txt", 'w') as file:
                    for line in final_data:
                        file.write(line)

                file_number += 1
                final_data = []

            i += 1

    print("Writing to file", file_number)
    with open("./" + output_file_name + str(file_number) + ".txt", 'w') as file:
        for line in final_data:
            file.write(line)

    print("All done writing data!")


if __name__ == "__main__":
    run()
