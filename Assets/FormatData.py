import os

#place_data_file_dir = "D:/Downloads/2022_place_canvas_history/2022_place_canvas_history.csv"
place_data_file_dir = "D:/Downloads/2022_place_canvas_history-000000000001/header.txt"

place_data_file_dir = "C:/Users/Charlton/AppData/LocalLow/Charlton Lane/rPlace3D/2022-compact.csv"

output_file = "C:/Users/Charlton/AppData/LocalLow/Charlton Lane/rPlace3D/cleanData.txt"


def run():
    final_data = []


    limit = 160353105 + 100
    i = 0

    has_skipped_first_line = False

    #print("Checking num lines")
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

            time = ((int)(split_line[0]) - 1648810000000)
            #print(time)
            color = split_line[2]
            position = ",".join([s.replace('"', "") for s in split_line[3:]])

            final_data.append((time, color + "|" + position))

            if (i % 1000000 == 0):
                print("Read",i,"lines")

            i += 1
            #if i >= limit:
            #    print("Hit limit of lines to read")
            #    break


    print("Starting Sort")
    final_data.sort(key=lambda tup: tup[0])


    print("Writing to file")
    with open(output_file, 'w') as file:
        for line in final_data:
            file.write(line[1])
        print("All done writing data!")

    

if __name__ == "__main__":
    run()